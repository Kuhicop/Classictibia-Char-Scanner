Imports System.IO
Imports System.Globalization
Imports System.ComponentModel

Public Class KuhiScan
    Private listfile As Integer = 1
    Private running As Boolean = True
    Private enemylistfile As String = Directory.GetCurrentDirectory + "\enemylist.txt"
    Private huntedlistfile As String = Directory.GetCurrentDirectory + "\huntedlist.txt"
    Private friendlistfile As String = Directory.GetCurrentDirectory + "\friendlist.txt"
    Private suspectlistfile As String = Directory.GetCurrentDirectory + "\suspectlist.txt"
    Private thrd As New Threading.Thread(AddressOf loopall)

    Private player_name As String
    Private player_level As String
    Private player_vocation As String

    Private sleeptime As Integer = 1000

    Private Sub KuhiScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        thrd.IsBackground = True
        thrd.Start()
    End Sub

    'Make Loop Sub
    Private Sub loopall()
        Label1.Text = "Into thread!"
        While running
            Dim txtfile As String = ""
            Dim datagrid As DataGridView = DataGridView1

            Select Case listfile
                Case 1
                    txtfile = enemylistfile
                    datagrid = DataGridView1
                Case 2
                    txtfile = huntedlistfile
                    datagrid = DataGridView2
                Case 3
                    txtfile = friendlistfile
                    datagrid = DataGridView3
                Case 4
                    txtfile = suspectlistfile
                    datagrid = DataGridView4
            End Select

            Dim reader = New StreamReader(txtfile)
            Try
                For Each Line As String In File.ReadLines(txtfile)
                    'Check settings
                    If txtfile = "" Then
                        reader.Close()
                        Exit Sub
                    End If
                    Debug.Print("Using file:" + txtfile)

                    'Read enemy name
                    player_name = reader.ReadLine()
                    If player_name.Contains(" ") Then
                        player_name.Replace(" ", "+")
                    End If
                    Debug.Print("Checking player: " + player_name)

                    'Read website response
                    Dim hotcount As Integer = 0
                    Dim url As String = New Net.WebClient().DownloadString("http://classictibia.com/characterprofile.php?name=" + player_name)
                    While (url.ToLower.Contains("chill down")) And (hotcount < 3)
                        Label1.Text = "HOT!"
                        Debug.Print("Website hot")
                        sleeptime += 200
                        hotcount += 1
                        Debug.Print("Sleeping for 5 sec...")
                        Threading.Thread.Sleep(5000)
                        url = New Net.WebClient().DownloadString("http://classictibia.com/characterprofile.php?name=" + player_name)
                    End While
                    Label1.Text = "OK!"
                    Debug.Print("Website cool, sleeptime = " + sleeptime.ToString)
                    Debug.Print("Searching for player: " + player_name)
                    hotcount = 0

                    If url.ToLower.Contains("does not exist") Then
                        'Player doesn't exists
                        MsgBox("Player " + player_name + " doesn't exist, remove it from:" + vbCrLf + Path.GetFileName(txtfile) + vbCrLf + "Software will close now.", MsgBoxStyle.Critical)
                        Environment.Exit(1)
                        Throw New System.Exception("Player doesn't exist.")
                    End If

                    'Get player level
                    Dim result As String = HTMLToText(url)
                    Dim aux = result
                    aux = aux.Replace(System.Environment.NewLine, "")
                    aux = aux.Replace(vbTab, "")
                    Dim cut_at As String = "Level:"
                    Dim x As Integer = InStr(aux, cut_at)

                    'Dim string_before As String = mystr.Substring(0, x - 2)
                    aux = aux.Substring(x + cut_at.Length - 1)
                    aux = aux.Remove(3)
                    player_level = aux
                    If player_level.Contains(" do") Then
                        Debug.Print(aux)
                        Throw New System.Exception(" do")
                    End If
                    Debug.Print("Player level is: " + player_level)

                    'Get player vocation
                    If HTMLToText(url).Contains("Druid") Then
                        player_vocation = "Druid"
                    ElseIf HTMLToText(url).Contains("Sorcerer") Then
                        player_vocation = "Sorcerer"
                    ElseIf HTMLToText(url).Contains("Paladin") Then
                        player_vocation = "Paladin"
                    Else
                        player_vocation = "Knight"
                    End If
                    Debug.Print("Player vocation is: " + player_vocation)

                    'Get player online time
                    aux = HTMLToText(url)
                    cut_at = "Last login:"
                    x = InStr(aux, cut_at)
                    aux = aux.Substring(x + cut_at.Length - 1)
                    x = InStr(aux, ")")
                    aux = aux.Remove(x)
                    Debug.Print("Last online:" + aux)

                    '28 June 2018 (22:05) example of timestring
                    Dim mydate = DateTime.ParseExact(aux, "dd MMMM yyyy (HH:mm)", CultureInfo.InvariantCulture)
                    Dim timenow As String = New Net.WebClient().DownloadString("http://just-the-time.appspot.com/")
                    Dim diffminutes = DateDiff(DateInterval.Minute, mydate, Convert.ToDateTime(timenow).AddHours(2))
                    Dim mytimespan = TimeSpan.FromMinutes(diffminutes)

                    For Each row As DataGridViewRow In datagrid.Rows
                        If row.Cells.Item(0).Value = player_name Then
                            datagrid.Rows.Remove(row)
                        End If
                    Next
                    Dim rowexample As String() = New String() {player_name, Nothing, Nothing, mytimespan.ToString("hh\:mm")}
                    datagrid.Rows.Add(rowexample)

                    For Each row As DataGridViewRow In datagrid.Rows
                        If row.Cells.Item(0).Value = player_name And player_vocation = "Druid" Then
                            row.Cells.Item(1).Value = My.Resources.paralyze
                        ElseIf row.Cells.Item(0).Value = player_name And player_vocation = "Knight" Then
                            row.Cells.Item(1).Value = My.Resources.sov
                        ElseIf row.Cells.Item(0).Value = player_name And player_vocation = "Paladin" Then
                            row.Cells.Item(1).Value = My.Resources.crossbow
                        ElseIf row.Cells.Item(0).Value = player_name And player_vocation = "Sorcerer" Then
                            row.Cells.Item(1).Value = My.Resources.sd
                        End If
                        If row.Cells.Item(0).Value = player_name Then
                            row.Cells.Item(2).Value = CInt(player_level)
                        End If
                    Next
                    If datagrid.Rows.Count > 0 Then
                        datagrid.Sort(datagrid.Columns(2), System.ComponentModel.ListSortDirection.Descending)
                        CType(datagrid.Columns(1), DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Stretch
                    End If

                    datagrid.CurrentCell = Nothing
                    Dim sleepiing As Decimal = sleeptime / 1000
                    Debug.Print("Sleeping for " + sleepiing.ToString + " secs...")
                    Threading.Thread.Sleep(sleeptime)
                Next

                If listfile >= 4 Then
                    listfile = 1
                Else
                    listfile += 1
                End If
            Catch ex As Exception
                Debug.Print(ex.ToString)
                Debug.Print("With player: " + player_name)
                Debug.Print("Player level: " + player_level)
                Debug.Print("Player vocation: " + player_vocation)
            End Try

            reader.Close()
        End While
    End Sub

    Private Sub KuhiScan_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Environment.Exit(1)
    End Sub
End Class
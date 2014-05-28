Imports System.Net
Imports System.IO

Public Class DSEDE

    Dim MSTLines() As String
    Dim StockLines() As String
    Dim StockInfo(,) As String
    Dim DSEXInfo(4) As String
    Dim DS30Info(4) As String
    Dim MSTDate, DSEXDate, DS30Date As Date

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click

        SetStatus("Retrieving MST Data...")
        Me.Cursor = Cursors.AppStarting

        Try
            If Not RetrieveMSTData() Then
                SetStatus("Could not retrieve MST File Data, check if MST file address is correct and you have internet connection")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            SetStatus("Processing MST File...")

            GetStockLines()

            ProcessStockLines()

            SetStatus("Getting Index Information...")

            GetIndexHighLow()

            If Not DoesMSTIndexDateMatch() Then
                SetStatus("DSEX/DS30 and MST Date not matching. Please try later when the MST file is updated on DSE's Website.")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            SetStatus("Writing CSV file...")

            If chkValidationCheck.Checked Then
                If Not ValidationCheckBeforeWritingCSV() Then
                    SetStatus("An Error occurred while retrieving stock and index info. Perhaps the format of DSE's MST file was changed. Contact the Developer.")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            WriteCSV()

        Catch ex As Exception
            SetStatus(ex.ToString)
        End Try

        Me.Cursor = Cursors.Default
        SetStatus("Done! CSV file saved to the specified location.")

    End Sub

    Private Function ValidationCheckBeforeWritingCSV() As Boolean
        Try
            Dim i As Short

            For i = 0 To 4
                Dim TempResult As Single
                If Not Single.TryParse(DSEXInfo(i), TempResult) Then
                    Return False
                End If

                If Not Single.TryParse(DS30Info(i), TempResult) Then
                    Return False
                End If
            Next

            For i = 0 To StockInfo.GetUpperBound(0) - 1
                If StockInfo(i, 0) <> "" Then
                    Dim j As Short
                    For j = 1 To 5
                        Dim TempResult As Single

                        If Not Single.TryParse(StockInfo(i, j), TempResult) Then
                            Return False
                        End If
                    Next
                End If
            Next

            If DSEXDate.Equals(DateTime.MinValue) Or DS30Date.Equals(DateTime.MinValue) Or MSTDate.Equals(DateTime.MinValue) Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub WriteCSV()
        Dim CSVName As String = "DSE_" & Format(MSTDate, "ddMMyy") & ".csv"
        Dim FinalCSVPath As String = cboDestinationFolder.Text & "\" & CSVName
        Dim CSVString = BuildCSVString()

        SaveTextToFile(CSVString, FinalCSVPath)
    End Sub

    Private Function BuildCSVString() As String
        Dim DSEXLine, DS30Line As String
        DSEXLine = cboIndexSymbolName.Text & "," & Format(MSTDate, "yyyy-MM-dd") & "," & _
            DSEXInfo(0) & "," & DSEXInfo(1) & "," & DSEXInfo(2) & "," & DSEXInfo(3) & "," & DSEXInfo(4)
        DS30Line = "DS30" & "," & Format(MSTDate, "yyyy-MM-dd") & "," & _
            DS30Info(0) & "," & DS30Info(1) & "," & DS30Info(2) & "," & DS30Info(3) & "," & DS30Info(4)

        BuildCSVString = DSEXLine & vbCrLf & DS30Line & vbCrLf

        Dim StockCounter As Short

        For StockCounter = 0 To StockInfo.GetUpperBound(0) - 1
            If StockInfo(StockCounter, 0) <> "" Then
                BuildCSVString += StockInfo(StockCounter, 0) & "," & Format(MSTDate, "yyyy-MM-dd") & _
                    "," & StockInfo(StockCounter, 1) & "," & StockInfo(StockCounter, 2) & _
                    "," & StockInfo(StockCounter, 3) & "," & StockInfo(StockCounter, 4) & _
                    "," & StockInfo(StockCounter, 5) & vbCrLf
            End If
        Next
    End Function

    Private Function DoesMSTIndexDateMatch() As Boolean
        If DSEXDate.Equals(MSTDate) And DS30Date.Equals(MSTDate) Then
            Return True
        End If

        Return False
    End Function

    Private Sub GetIndexHighLow()
        Dim DSEXData As String = GetPage("http://dsebd.org/index-graph/companygraph.php?graph_id=dsbi")
        Dim DS30Data As String = GetPage("http://dsebd.org/index-graph/companygraph.php?graph_id=ds30")

        DSEXInfo(1) = Trim(Strings.Mid(DSEXData, DSEXData.IndexOf("Highest value:</strong> ") + 24, 10))
        DSEXInfo(2) = Trim(Strings.Mid(DSEXData, DSEXData.IndexOf("Lowest value:</strong> ") + 23, 10))
        DS30Info(1) = Trim(Strings.Mid(DS30Data, DS30Data.IndexOf("Highest value:</strong> ") + 24, 10))
        DS30Info(2) = Trim(Strings.Mid(DS30Data, DS30Data.IndexOf("Lowest value:</strong> ") + 23, 10))

        DSEXDate = Strings.Mid(DSEXData, DSEXData.IndexOf(" of ") + 4, 11)
        DS30Date = Strings.Mid(DS30Data, DS30Data.IndexOf(" of ") + 4, 11)
    End Sub

    Public Function SaveTextToFile(ByVal strData As String, _
     ByVal FullPath As String, _
       Optional ByVal ErrInfo As String = "") As Boolean

        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message

        End Try
        Return bAns
    End Function

    Private Function GetDesktopDirectory() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Function

    Private Sub ProcessStockLines()
        Dim i As Short
        ReDim StockInfo(StockLines.Length, 5)

        For i = 0 To StockLines.Length - 1
            Dim TempStockLine As String = StockLines(i)

            StockInfo(i, 0) = Trim(Strings.Mid(TempStockLine, 2, 11))
            StockInfo(i, 1) = Trim(Strings.Mid(TempStockLine, 12, 9))
            StockInfo(i, 2) = Trim(Strings.Mid(TempStockLine, 21, 9))
            StockInfo(i, 3) = Trim(Strings.Mid(TempStockLine, 30, 9))
            StockInfo(i, 4) = Trim(Strings.Mid(TempStockLine, 39, 9))
            StockInfo(i, 5) = Trim(Strings.Mid(TempStockLine, 62, 10))
        Next
    End Sub

    Private Function IsThisStockLine(Line As String) As Boolean
        If Line <> "" Then
            If ((Line.Length = 81) Or (Line.Length = 80)) And (Not String.IsNullOrWhiteSpace(Strings.Left(Line, 2))) And (IsNumeric(Strings.Right(Line, 2))) Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub GetStockLines()
        Dim i, SubCounter As Short
        For i = 0 To MSTLines.Length - 1
            If IsThisStockLine(MSTLines(i)) Then
                ReDim Preserve StockLines(SubCounter)
                StockLines(SubCounter) = MSTLines(i)
                SubCounter += 1
            End If

            If (MSTLines(i).StartsWith(vbLf & "DS30")) Then
                DS30Info(0) = Trim(Strings.Mid(MSTLines(i), 12, 15))
                DS30Info(3) = Trim(Strings.Mid(MSTLines(i), 27))
            End If

            If (MSTLines(i).StartsWith(vbLf & "DSEX")) Then
                DSEXInfo(0) = Trim(Strings.Mid(MSTLines(i), 12, 15))
                DSEXInfo(3) = Trim(Strings.Mid(MSTLines(i), 27))
            End If

            If (MSTLines(i).StartsWith(vbLf & "    C. VALUE(Tk)")) Then
                Dim IndexTradeValue As String = Trim(Strings.Mid(MSTLines(i), 40) / 100)
                DSEXInfo(4) = IndexTradeValue
                DS30Info(4) = IndexTradeValue
            End If

            If (MSTLines(i).StartsWith(vbLf & "                  TODAY'S SHARE MARKET")) Then
                MSTDate = Date.Parse(Strings.Right(MSTLines(i), 10))
            End If
        Next
    End Sub

    Private Sub SetStatus(ByVal Message As String)
        txtStatus.Text = Message
    End Sub

    Private Function RetrieveMSTData() As Boolean
        Dim MSTData As String = GetPage(cboMSTSource.Text)
        If MSTData = "" Then
            Return False
        End If

        MSTLines = MSTData.Split(Chr(13))
        Return True
    End Function

    Private Function GetPage(ByVal PageURL As String) As String
        Dim S As String = ""
        Try
            Dim Request As HttpWebRequest = WebRequest.Create(PageURL)
            Dim Response As HttpWebResponse = Request.GetResponse()
            Using Reader As StreamReader = New StreamReader(Response.GetResponseStream())
                S = Reader.ReadToEnd
            End Using
        Catch ex As Exception
            S = ""
        End Try
        Return S
    End Function

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim DesktopDir As String = GetDesktopDirectory()
        cboDestinationFolder.Items.Add(DesktopDir)
        cboDestinationFolder.Text = DesktopDir
    End Sub
End Class

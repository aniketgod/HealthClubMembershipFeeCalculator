Public Class Form1
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim decBaseFee As Decimal
        Dim decTotalFee As Decimal
        Dim intMonths As Integer
        Dim blnInputOk As Boolean = True

        ' constant for base fees
        Const decADULT_FEE As Decimal = 40D
        Const decCHILD_FEE As Decimal = 20D
        Const decSTUDENT_FEE As Decimal = 25D
        Const decSENIOR_FEE As Decimal = 30D

        ' constants for additional fee
        Const decYOGA_FEE As Decimal = 10D
        Const decKARATE_FEE As Decimal = 30D
        Const decTRAINER_FEE As Decimal = 50D

        ' Validate the convert the number of months
        lblStatus.Text = String.Empty
        If Integer.TryParse(txtMonths.Text, intMonths) = False Then
            lblStatus.Text = "Months Must be Integer."
            blnInputOk = False
        End If

        ' Validate and convert the number of months
        If intMonths < 1 Or intMonths > 24 Then
            lblStatus.Text = "Months must be in a range 1-24."
            blnInputOk = False
        End If

        If blnInputOk = True Then
            ' Determine  the base monthly fee
            If radAdult.Checked = True Then
                decBaseFee = decADULT_FEE
            End If
            If radChild.Checked = True Then
                decBaseFee = decCHILD_FEE
            End If
            If radStudent.Checked = True Then
                decBaseFee = decSTUDENT_FEE
            End If
            If radSenior.Checked = True Then
                decBaseFee = decSENIOR_FEE
            End If

            ' Check additional service
            If chkYoga.Checked = True Then
                decBaseFee += decYOGA_FEE
            End If
            If chkKarate.Checked = True Then
                decBaseFee += decKARATE_FEE
            End If
            If chkTrainer.Checked = True Then
                decBaseFee += decTRAINER_FEE
            End If

            ' Calculate the total fee
            decTotalFee = decBaseFee * intMonths

            ' Display the fees
            lblMonthlyFee.Text = decBaseFee.ToString("c")
            lblTotalFee.Text = decTotalFee.ToString("c")
        End If
    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' Reset adult radio button
        radAdult.Checked = True

        ' Clear the check boxes
        chkYoga.Checked = False
        chkKarate.Checked = False
        chkTrainer.Checked = False

        ' Clear the number of months
        txtMonths.Clear()

        ' clear the fee labels
        lblMonthlyFee.Text = String.Empty
        lblTotalFee.Text = String.Empty
        lblStatus.Text = String.Empty

        ' Give txtMonths Focus
        txtMonths.Focus()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ' close the form
        Me.Close()
    End Sub

End Class

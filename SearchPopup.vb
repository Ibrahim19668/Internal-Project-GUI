Public Class SearchPopup

    Public editval As Integer
    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MainForm.searchoredit = True Then
            Dim eng() = MainForm.eng
            Dim sci() = MainForm.sci
            Dim id() = MainForm.id
            Dim mat() = MainForm.mat


            Me.Hide()
            For i = 0 To id.GetUpperBound(0)
                If Convert.ToString(id(i)) = Me.ListBox1.SelectedItem.ToString Then
                    Display.TextBox2.Text = ""
                    Display.TextBox3.Text = ""
                    Display.TextBox4.Text = ""
                    Display.TextBox5.Text = ""
                    Display.TextBox6.Text = ""
                    Display.TextBox6.Text += "ID" + Environment.NewLine + "_________"
                    Display.TextBox2.Text += "English" + Environment.NewLine + "__________"
                    Display.TextBox3.Text += "Math" + " __________"
                    Display.TextBox4.Text += "Science" + Environment.NewLine + "__________"
                    Display.TextBox5.Text += "Average" + Environment.NewLine + "__________"
                    Dim output As String
                    output = Convert.ToString(id(i))
                    Display.TextBox6.Text += output

                    output = Convert.ToString(eng(i))
                    Display.TextBox2.Text += output
                    output = Convert.ToString(mat(i))
                    Display.TextBox3.Text += output
                    output = Convert.ToString(sci(i))
                    Display.TextBox4.Text += output
                    output = Convert.ToString(Convert.ToInt32((eng(i) + mat(i) + sci(i)) / 3))
                    Display.TextBox5.Text += output
                    Display.Show()
                End If
            Next
        Else

            editval = ListBox1.SelectedIndex + 1
            InputForm.TextBox1.ReadOnly = True
            InputForm.TextBox1.Text = Convert.ToString(MainForm.id(editval))
            InputForm.TextBox2.Text = ""
            InputForm.TextBox3.Text = ""
            InputForm.TextBox4.Text = ""
            InputForm.Show()
            InputForm.TextBox2.Focus()
            Me.Hide()
        End If
    End Sub


End Class
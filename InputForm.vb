Public Class InputForm

    Public overwriteval As Integer ' it will be the index for an overwrite subroutine

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox2.Focus() ' focusses on the next textbox or button in the case of the last one
        End If
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox4.Focus()
        End If
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim exitinput As Boolean = True ' this is used to control what happens if a user turns of the input poppup before inputting data
        If MainForm.inputoredit = True Then
            arraysize1() ' increases arraysize
            Try
                If Convert.ToInt32(TextBox1.Text) < 100000 And Convert.ToInt32(TextBox1.Text) > 9999 And Convert.ToInt32(TextBox1.Text) >= 0 And Convert.ToInt32(TextBox2.Text) <= 100 And Convert.ToInt32(TextBox2.Text) >= 0 And Convert.ToInt32(TextBox3.Text) <= 100 And Convert.ToInt32(TextBox4.Text) >= 0 And Convert.ToInt32(TextBox4.Text) <= 100 Then

                    fix()
                    For i = 1 To MainForm.id.GetUpperBound(0)
                        If MainForm.id(i) = Convert.ToInt32(TextBox1.Text) Then
                            overwriteval = i ' checks is an id is repeated then opens up overwrite popup
                            arraysize2()
                            Overwritepopup.Show()

                            exitinput = False
                            Exit Try
                        End If
                    Next
                    MainForm.id(MainForm.id.GetUpperBound(0)) = Convert.ToInt32(TextBox1.Text) ' inputs data to individual arrays if valid
                    MainForm.eng(MainForm.id.GetUpperBound(0)) = Convert.ToInt32(TextBox2.Text)
                    MainForm.mat(MainForm.id.GetUpperBound(0)) = Convert.ToInt32(TextBox3.Text)
                    MainForm.sci(MainForm.id.GetUpperBound(0)) = Convert.ToInt32(TextBox4.Text)
                    exitinput = False
                    Me.Hide()


                Else




                    MessageBox.Show("Data was not entered correctly!!")
                    TextBox1.Text = ""
                    TextBox3.Text = ""
                    TextBox2.Text = ""
                    TextBox4.Text = ""
                    TextBox1.Focus()
                    Exit Try ' tells user if they didn't enter a valid id or subject score resets textboxes and returns to the first text box for input

                End If

            Catch ex As Exception




                MessageBox.Show("Data was not entered correctly!!")
                TextBox1.Text = ""
                TextBox3.Text = ""
                TextBox2.Text = ""
                TextBox4.Text = ""
                TextBox1.Focus() ' tells user if they didn't enter a valid id or subject score resets textboxes and returns to the first text box for input
                Exit Try


            End Try

            If exitinput = True Then
                arraysize2()
            End If

        Else

            Try
                If Convert.ToInt32(TextBox1.Text) < 100000 And Convert.ToInt32(TextBox1.Text) > 9999 And Convert.ToInt32(TextBox1.Text) >= 0 And Convert.ToInt32(TextBox2.Text) <= 100 And Convert.ToInt32(TextBox2.Text) >= 0 And Convert.ToInt32(TextBox3.Text) <= 100 And Convert.ToInt32(TextBox4.Text) >= 0 And Convert.ToInt32(TextBox4.Text) <= 100 Then
                    fix()
                    MainForm.eng(SearchPopup.editval) = Convert.ToInt32(TextBox2.Text) ' does essentially the same thing as the normal input but an index is being overwritten
                    MainForm.mat(SearchPopup.editval) = Convert.ToInt32(TextBox3.Text)
                    MainForm.sci(SearchPopup.editval) = Convert.ToInt32(TextBox4.Text)
                    Me.Hide()
                Else
                    MessageBox.Show("Data was not entered correctly!!")
                    TextBox3.Text = ""
                    TextBox2.Text = ""
                    TextBox4.Text = ""
                    TextBox2.Focus() ' tells user if they didn't enter a valid id or subject score resets textboxes and returns to the first text box for input
                End If
            Catch ex As Exception
                MessageBox.Show("Data was not entered correctly!!")
                TextBox3.Text = ""
                TextBox2.Text = ""
                TextBox4.Text = ""
                TextBox2.Focus() ' tells user if they didn't enter a valid id or subject score resets textboxes and returns to the first text box for input
            End Try

        End If
    End Sub ' the main code for input . it validates and inputs into correct array

    Public Sub fix() ' used to increase to 20 if less than 20
        If Convert.ToInt32(TextBox2.Text) < 20 Then
            TextBox2.Text = "20"
        End If
        If Convert.ToInt32(TextBox3.Text) < 20 Then
            TextBox3.Text = "20"
        End If
        If Convert.ToInt32(TextBox4.Text) < 20 Then
            TextBox4.Text = "20"
        End If


    End Sub

    Public Sub arraysize1()
        Dim arraysize As Integer = MainForm.id.Length
        Array.Resize(MainForm.id, arraysize + 1) ' used to dynamically change the arraysize up
        Array.Resize(MainForm.sci, arraysize + 1)
        Array.Resize(MainForm.eng, arraysize + 1)
        Array.Resize(MainForm.mat, arraysize + 1)

    End Sub ' increases arrasize

    Public Sub arraysize2()
        Dim arraysize As Integer = MainForm.id.Length
        Array.Resize(MainForm.id, arraysize - 1) ' used to dynamically change the arraysize down
        Array.Resize(MainForm.sci, arraysize - 1)
        Array.Resize(MainForm.eng, arraysize - 1)
        Array.Resize(MainForm.mat, arraysize - 1)
    End Sub ' decreases array size

End Class
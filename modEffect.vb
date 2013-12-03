Imports System.Drawing.Imaging

Module modEffect

    Public Function IsKeyframe(ByRef input1 As Bitmap, ByRef input2 As Bitmap, _
                               ByVal threshold As Double, ByVal similarity As Double) As Boolean
        Dim diff As Integer = 0
        Dim total As Integer = 0
        For x As Integer = input1.Width / 4 To input1.Width * 3 / 4
            For y As Integer = input1.Height / 4 To input1.Height * 3 / 4
                total = total + 1
                Dim c1 As Color = input1.GetPixel(x, y)
                Dim c2 As Color = input2.GetPixel(x, y)
                Dim red As Integer = Math.Abs(CInt(c1.R) - CInt(c2.R))
                Dim green As Integer = Math.Abs(CInt(c1.G) - CInt(c2.G))
                Dim blue As Integer = Math.Abs(CInt(c1.B) - CInt(c2.B))
                Dim colorDiff As Double = CDbl(red + green + blue) / CDbl(255 * 3)
                If colorDiff > threshold Then
                    diff = diff + 1
                End If
            Next
        Next
        If (CDbl(diff) / CDbl(total) > similarity) Then
            Return True
        End If

        Return False
    End Function

    Public Function FadeIn(ByRef input As Bitmap, ByVal startRate As Double, _
                           ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer) As Bitmap
        Dim output As New Bitmap(input.Width, input.Height, Imaging.PixelFormat.Format24bppRgb)
        Dim ratio As Double
        ratio = CDbl(currentIndex - startFrame) / CDbl(endFrame - startFrame)
        Dim r, g, b As Integer
        Dim c As Color
        For x As Integer = 0 To output.Width - 1
            For y As Integer = 0 To output.Height - 1
                c = GetPixel(input, x, y)
                r = c.R * (startRate + (1 - startRate) * ratio)
                g = c.G * (startRate + (1 - startRate) * ratio)
                b = c.B * (startRate + (1 - startRate) * ratio)
                output.SetPixel(x, y, Color.FromArgb(r, g, b))
            Next
        Next

        Return output
    End Function

    Public Function FadeOut(ByRef input As Bitmap, ByVal endRate As Double, _
                            ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer) As Bitmap
        Dim output As New Bitmap(input.Width, input.Height, Imaging.PixelFormat.Format24bppRgb)

        Dim ratio As Double
        ratio = CDbl(currentIndex - startFrame) / CDbl(endFrame - startFrame)
        Dim multiplier As Double
        multiplier = 1 - ratio
        Dim r, g, b As Integer
        Dim c As Color
        For x As Integer = 0 To output.Width - 1
            For y As Integer = 0 To output.Height - 1
                c = GetPixel(input, x, y)
                r = c.R * (endRate + (1 - endRate) * multiplier)
                g = c.G * (endRate + (1 - endRate) * multiplier)
                b = c.B * (endRate + (1 - endRate) * multiplier)
                output.SetPixel(x, y, Color.FromArgb(r, g, b))
            Next
        Next

        Return output
    End Function

    Dim frames As Generic.List(Of Bitmap) = New Generic.List(Of Bitmap)

'    Public Function MotionBlur(ByRef input As Bitmap, ByVal blurCount As Integer, _
'                               ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer, ByVal newOp As Boolean, _
'                               ByVal dirname As String) As Bitmap
'        Dim output As New Bitmap(input.Width, input.Height, Imaging.PixelFormat.Format24bppRgb)
'
'        Dim r, g, b As Integer
'        Dim c As Color
'        Dim buffer As Bitmap = New Bitmap(input.Width, input.Height, Imaging.PixelFormat.Format24bppRgb)
'
'        If (frames.Count = blurCount) Then
'
'            For frame As Integer = currentIndex - blurCount + 1 To currentIndex
'                For x As Integer = 0 To output.Width - 1
'                    For y As Integer = 0 To output.Height - 1
'                        c = GetPixel(input, x, y)
'                        r = c.R + GetPixel(frames.Item(frame), x, y).R
'                        g = c.G + GetPixel(frames.Item(frame), x, y).G
'                        b = c.B + GetPixel(frames.Item(frame), x, y).B
'                        buffer.SetPixel(x, y, Color.FromArgb(r, g, b))
'                    Next
'                Next
'            Next
'
'            For x As Integer = 0 To output.Width - 1
'                For y As Integer = 0 To output.Height - 1
'                    c = GetPixel(buffer, x, y)
'                    r = c.R / blurCount
'                    g = c.G / blurCount
'                    b = c.B / blurCount
'                    output.SetPixel(x, y, Color.FromArgb(r, g, b))
'                Next
'            Next
'
'            frames.Clear()
'        Else
'            frames.Add(input)
'        End If
'
'        Return output
'    End Function

    Public Function MotionBlur(ByRef input As Bitmap, ByVal blurCount As Integer, _
                                  ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer, ByVal newOp As Boolean, _
                                  ByVal dirname As String) As Bitmap
        Dim output As New Bitmap(input.Width, input.Height, Imaging.PixelFormat.Format24bppRgb)
        ' You need to initialize the buffers at the start of the operation

        Static Dim bufferR(input.Width, input.Height) As Integer
        Static Dim bufferG(input.Width, input.Height) As Integer
        Static Dim bufferB(input.Width, input.Height) As Integer
        Dim startIndex As Integer
        Array.Clear(bufferR, 0, bufferR.Length)
        Array.Clear(bufferG, 0, bufferG.Length)
        Array.Clear(bufferB, 0, bufferB.Length)
        If ((currentIndex - blurCount + 1) < 0) Then
            startIndex = 0
        Else
            startIndex = currentIndex - blurCount + 1
        End If


        For frameNo As Integer = startIndex To currentIndex
            Dim frame As Bitmap = New Bitmap(dirname & "\f" & CStr(frameNo) & ".bmp")
            Dim fpin As New FastPixel(frame)
            fpin.Lock()
            For x As Integer = 0 To input.Width - 1
                For y As Integer = 0 To input.Height - 1
                    bufferR(x, y) = (bufferR(x, y) + fpin.GetPixel(x, y).R)
                    bufferG(x, y) = (bufferG(x, y) + fpin.GetPixel(x, y).G)
                    bufferB(x, y) = (bufferB(x, y) + fpin.GetPixel(x, y).B)
                Next
            Next
            fpin.Unlock(True)
        Next

        Dim fpout As New FastPixel(output)
        fpout.Lock()
        For x As Integer = 0 To input.Width - 1
            For y As Integer = 0 To input.Height - 1
                Dim red As Integer = Math.Round((bufferR(x, y) / blurCount))
                Dim green As Integer = Math.Round((bufferG(x, y) / blurCount))
                Dim blue As Integer = Math.Round((bufferB(x, y) / blurCount))
                fpout.SetPixel(x, y, Color.FromArgb(red, green, blue))
            Next
        Next

        fpout.Unlock(True)
        output = fpout.Bitmap

        Return output
    End Function


    Public Function Ripple(ByRef input As Bitmap, ByVal amplitude As Integer, ByVal frequency As Integer, _
                           ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer, ByVal startradius As Double) As Bitmap
        Dim output As New Bitmap(input.Width, input.Height, Imaging.PixelFormat.Format24bppRgb)

        Dim center As New PointF(input.Width / 2.0#, input.Height / 2.0#)
        Dim diagonal As Double = Math.Sqrt(input.Width ^ 2 + input.Height ^ 2)
        Dim ratio As Double = CDbl(currentIndex - startFrame) / CDbl(endFrame - startFrame)
        Dim frameradius As Double = diagonal / 2.0# * ratio
        For x As Integer = 0 To output.Width - 1
            For y As Integer = 0 To output.Height - 1
                Dim radius As Double = Math.Sqrt((x - center.X) ^ 2 + (y - center.Y) ^ 2)
                Dim angle As Double = Math.Atan2(y - center.Y, x - center.X)
                Dim c As Color
                If radius > frameradius Or frameradius = 0 Then
                    c = GetPixel(input, x, y)
                Else
                    Dim offset As Double = amplitude * Math.Sin(2 * Math.PI * frequency * (radius / frameradius))
                    Dim newRadius As Double = radius + offset
                    Dim newX As Integer = (newRadius * Math.Cos(angle)) + center.X
                    Dim newY As Integer = input.Height - ((-newRadius * Math.Sin(angle)) + center.Y)
                    c = GetPixel(input, CInt(newX), CInt(newY))
                End If
                output.SetPixel(x, y, c)
            Next
        Next

        Return output
    End Function

    Public Function Melt(ByRef input As Bitmap, _
                         ByVal useSine As Boolean, ByVal amplitude As Integer, ByVal cycle As Integer, _
                         ByVal useRandom As Boolean, ByVal offset As Integer, ByVal period As Integer, _
                         ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer, ByVal newOp As Boolean) As Bitmap
        Dim output As New Bitmap(input.Width, input.Height, Imaging.PixelFormat.Format24bppRgb)
        Static Dim displacement() As Integer = Nothing

        If newOp Then
            ReDim displacement(input.Width - 1)
            If useSine Then
                For x As Integer = 0 To input.Width - 1
                    displacement(x) = displacement(x) + Math.Abs(amplitude * Math.Sin(2.0# * Math.PI * cycle * x / (input.Width - 1)))
                Next
            End If
            If useRandom Then
                Dim currentOffset As Integer
                Dim currentPeriod As Integer
                Dim sign As Integer
                Dim x As Integer = 0

                While x < input.Width
                    currentPeriod = 1 + Rnd() * (period - 1)
                    If (Rnd() >= 0.5) Then
                        sign = 1
                    Else
                        sign = -1
                    End If
                    For i As Integer = x To x + currentPeriod - 1
                        currentOffset = currentOffset + sign * Rnd() * offset
                        If currentOffset < 0 Then
                            currentOffset = -1 * currentOffset
                            sign = -1 * sign
                        End If
                        If i < input.Width Then
                            displacement(i) = displacement(i) + currentOffset
                        End If
                    Next
                    x = x + currentPeriod
                End While
            End If
        End If

        Dim ratio As Double = ((currentIndex - startFrame)/(endFrame - startFrame))
        Dim c As Color
        For p As Integer = 0 To output.Width - 1
            For q As Integer = 0 To output.Height - 1
                Dim r As Integer = (q - displacement (p)*ratio)
                If p < 0 Then
                    p = 0
                ElseIf p > input.Width - 1 Then
                    p = input.Width - 1
                End If

                If r < 0 Then
                    r = 0
                ElseIf r > input.Height - 1 Then
                    r = input.Height - 1
                End If
                c = input.GetPixel (p, r)
                output.SetPixel (p, q, c)
            Next
        Next
        Return output
    End Function

    Public Function Transition(ByRef input1 As Bitmap, ByRef input2 As Bitmap, ByVal type As Integer,
                                ByVal duration As Double, ByVal orientation As Integer,
                                ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer,
                                ByVal newOp As Boolean) As Bitmap
        Dim output As New Bitmap(input1.Width, input1.Height, PixelFormat.Format24bppRgb)
        Dim TransLast As Integer = (endFrame - startFrame) * duration
        Dim TransStart As Integer = ((endFrame - startFrame) - TransLast) / 2 + startFrame
        Dim percentage As Double = (currentIndex - TransStart) / TransLast
        Dim widthBound As Integer = input1.Width - 1
        Dim heightBound As Integer = input1.Height - 1

        Static IsInput2(input1.Height - 1) As Boolean
        Static rate As Double = IsInput2.Length() / TransLast
        Static IsEnd As Boolean = False

        Dim s, t As Integer

        Dim fpin1 As FastPixel = New FastPixel(input1)
        Dim fpin2 As FastPixel = New FastPixel(input2)
        Dim fpout As FastPixel = New FastPixel(output)

        fpin1.Lock()
        fpin2.Lock()
        fpout.Lock()

        Select Case type

            'Wipe
            Case 0
                Dim condition As Boolean = False

                For x As Integer = 0 To widthBound
                    For y As Integer = 0 To heightBound

                        Select Case orientation
                            Case 1
                                condition = x / input1.Width < percentage
                            Case 0
                                condition = (input1.Width - x) / input1.Width < percentage
                            Case 3
                                condition = y / input1.Height < percentage
                            Case 2
                                condition = (input1.Height - y) / input1.Height < percentage
                        End Select

                        If condition Then
                            fpout.SetPixel(x, y,
                                       fpin2.GetPixel(((x * fpin2.Width) / fpin1.Width), ((y * fpin2.Height) / fpin1.Height)))
                        Else
                            fpout.SetPixel(x, y, fpin1.GetPixel(x, y))
                        End If
                    Next
                Next
                'dissolve
            Case 1
                If newOp Then
                    IsInput2 = New Boolean(input1.Height - 1) {}
                    ReDim IsInput2(input1.Height - 1)
                    rate = IsInput2.Length / IIf(TransLast = 0, 1, TransLast)
                    IsEnd = False
                End If
                If (currentIndex >= TransStart) Then
                    For s = 1 To rate
                        Dim random As New Random
                        Dim index As Integer = random.Next((input1.Height - 1))
                        Dim max As Integer = 1000
                        Do While IsInput2(index)
                            max -= 1
                            If (max = 0) Then
                                IsEnd = True
                                Exit Do
                            End If
                            index = random.Next((input1.Height - 1))
                        Loop
                        IsInput2(index) = True
                    Next
                End If
                If IsEnd Then
                    For t = 0 To heightBound
                        IsInput2(t) = True
                    Next
                End If
                Dim outWidthBound As Integer = output.Width - 1
                Dim outHeightBound As Integer = output.Height - 1
                For s = 0 To outWidthBound
                    For t = 0 To outHeightBound
                        If IsInput2(t) Then
                            fpout.SetPixel(s, t,
                                            fpin2.GetPixel((s * input2.Width) / input1.Width, (t * input2.Height) / input1.Height))
                        Else
                            fpout.SetPixel(s, t, fpin1.GetPixel(s, t))
                        End If
                    Next
                Next
        End Select

        fpin1.Unlock(True)
        fpin2.Unlock(True)
        fpout.Unlock(True)
        output = fpout.Bitmap
        Return output
    End Function

    Public Function Timeshift (ByRef input1 As Bitmap, ByRef input2 As Bitmap, ByVal position As Integer,
                               ByVal region As Integer,
                               ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer,
                               ByVal newOp As Boolean) As Bitmap
        Dim output As New Bitmap (input1.Width, input1.Height, PixelFormat.Format24bppRgb)
        Dim fpin1 As FastPixel = New FastPixel (input1)
        Dim fpin2 As FastPixel = New FastPixel (input2)
        Dim fpout As FastPixel = New FastPixel (output)
        Dim cutoff As Integer = input1.Width*position/100

        fpin1.Lock()
        fpin2.Lock()
        fpout.Lock()

        For x As Integer = 0 To input1.Width - 1
            For y As Integer = 0 To input1.Height - 1
                If (x >= cutoff - region/2) And (x <= cutoff + region/2) Then
                    Dim ratio As Double = (x - (cutoff - region/2))/region
                    If x < 0 Then
                        x = 0
                    ElseIf x > fpin1.Width - 1 Then
                        x = fpin1.Width - 1
                    End If

                    If y < 0 Then
                        y = 0
                    ElseIf y > fpin1.Height - 1 Then
                        y = fpin1.Height - 1
                    End If
                    Dim c1 As Color = fpin1.GetPixel (x, y)
                    If x > fpin2.Width - 1 Then
                        x = fpin2.Width - 1
                    End If
                    If y > fpin2.Height - 1 Then
                        y = fpin2.Height - 1
                    End If
                    Dim c2 As Color = fpin2.GetPixel (x, y)
                    Dim red, green, blue As Integer
                    red = c1.R*(1 - ratio) + c2.R*ratio
                    green = c1.G*(1 - ratio) + c2.G*ratio
                    blue = c1.B*(1 - ratio) + c2.B*ratio
                    fpout.SetPixel (x, y, Color.FromArgb (red, green, blue))
                ElseIf (x < cutoff - region/2) Then
                    fpout.SetPixel (x, y, fpin1.GetPixel (x, y))
                ElseIf (x > cutoff + region/2) Then
                    fpout.SetPixel (x, y, fpin2.GetPixel (x, y))
                End If
            Next
        Next

        fpin1.Unlock (True)
        fpin2.Unlock (True)
        fpout.Unlock (True)
        Return output
    End Function

    ' Get the pixel from the bitmap with the boundary pixels correctly handled
    Private Function GetPixel(ByRef bitmap As Bitmap, ByVal x As Short, ByVal y As Short) As Color
        If x < 0 Then
            x = 0
        ElseIf x > bitmap.Width - 1 Then
            x = bitmap.Width - 1
        End If

        If y < 0 Then
            y = 0
        ElseIf y > bitmap.Height - 1 Then
            y = bitmap.Height - 1
        End If

        GetPixel = bitmap.GetPixel(x, y)
    End Function

    ' Clipping function
    Private Function Clip(ByVal value As Integer) As Integer
        If value > 255 Then
            Return 255
        ElseIf value < 0 Then
            Return 0
        End If
        Return value
    End Function

End Module

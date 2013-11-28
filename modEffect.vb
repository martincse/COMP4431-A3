Module modEffect

    Public Function IsKeyframe(ByRef input1 As Bitmap, ByRef input2 As Bitmap, _
                               ByVal threshold As Double, ByVal similarity As Double) As Boolean

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

    Public Function MotionBlur(ByRef input As Bitmap, ByVal blurCount As Integer, _
                               ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer, ByVal newOp As Boolean, _
                               ByVal dirname As String) As Bitmap
        Dim output As New Bitmap(input.Width, input.Height, Imaging.PixelFormat.Format24bppRgb)
        ' You need to initialize the buffers at the start of the operation

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

        Return output
    End Function

    Public Function Transition(ByRef input1 As Bitmap, ByRef input2 As Bitmap, ByVal type As Integer, ByVal duration As Double, ByVal orientation As Integer, _
                               ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer, ByVal newOp As Boolean) As Bitmap
        Dim output As New Bitmap(input1.Width, input1.Height, Imaging.PixelFormat.Format24bppRgb)
    
        Return output
    End Function
    Public Function Timeshift(ByRef input1 As Bitmap, ByRef input2 As Bitmap, ByVal position As Integer, ByVal region As Integer, _
                               ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer, ByVal newOp As Boolean) As Bitmap
        Dim output As New Bitmap(input1.Width, input1.Height, Imaging.PixelFormat.Format24bppRgb)

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

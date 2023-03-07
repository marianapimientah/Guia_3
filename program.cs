using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class program : MonoBehaviour
{
    //Presentado por Mariana Pimienta Hernandez
    float Height = 254, Width = 254;

    Texture2D texture;
    static readonly Stopwatch timer = new Stopwatch();
    void Start()
    {
        Color Back = new Color(0, 0, 0, 1);
        Setup(Height, Width, Back);

        //Metodo ABasico Color Azul
        timer.Start();
        double Tinicial0 = timer.Elapsed.TotalMilliseconds;
        Color LineColor = new Color(0, 0, 1, 1);
        double Tfinal0 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal0 = Tfinal0 - Tinicial0;
        print(Ttotal0);

        timer.Start();
        double Tinicial1 = timer.Elapsed.TotalMilliseconds;
        TrianguloAB(205, 15, 25, 45, 45, 5, LineColor);
        texture.Apply();
        double Tfinal1 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal1 = Tfinal1 - Tinicial1;
        print(Ttotal1);

        timer.Start();
        double Tinicial2 = timer.Elapsed.TotalMilliseconds;
        CuadradoAB(30, 200, 30, 30, LineColor);
        texture.Apply();
        double Tfinal2 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal2 = Tfinal2 - Tinicial2;
        print(Ttotal2);

        timer.Start();
        double Tinicial3 = timer.Elapsed.TotalMilliseconds;
        float sui = Height / 8;
        PentagonoAB(Height / 2.0f,Width/2.0f, sui, LineColor);
        texture.Apply();
        double Tfinal3 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal3 = Tfinal3 - Tinicial3;
        print(Ttotal3);

        timer.Start();
        double Tinicial4 = timer.Elapsed.TotalMilliseconds;
        HexagonoAB(Height / 1.2f, Width / 1.2f, sui, LineColor);
        texture.Apply();
        double Tfinal4 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal4 = Tfinal4 - Tinicial4;
        print(Ttotal4);


        //Metodo Abressenham Color Rosado
        Color LineColor2 = new Color(1, 0, 1, 1);
        timer.Start();
        double Tinicial5 = timer.Elapsed.TotalMilliseconds;
        TrianguloA(5, 5, 35, 35, 35, 5, LineColor2);
        texture.Apply();
        double Tfinal5 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal5 = Tfinal5 - Tinicial5;
        print(Ttotal5);


        timer.Start();
        double Tinicial6 = timer.Elapsed.TotalMilliseconds;
        CuadradoA(100, 200, 30, 30, LineColor2);
        texture.Apply();
        double Tfinal6 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal6 = Tfinal6 - Tinicial6;
        print(Ttotal6);

        timer.Start();
        double Tinicial7 = timer.Elapsed.TotalMilliseconds;
        PentagonoA(Height / 5.0f, Width / 2.0f, sui, LineColor2);
        texture.Apply();
        double Tfinal7 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal7 = Tfinal7 - Tinicial7;
        print(Ttotal7);


        timer.Start();
        double Tinicial8 = timer.Elapsed.TotalMilliseconds;
        HexagonoA(Height / 1.2f, Width / 5.0f, sui, LineColor2);
        texture.Apply();
        double Tfinal8 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal8 = Tfinal8 - Tinicial8;
        print(Ttotal8);


        //Metodo ADDA Color verde
        Color LineColor3 = new Color(0, 1, 0, 1);
        timer.Start();
        double Tinicial9 = timer.Elapsed.TotalMilliseconds;
        TrianguloADDA(15, 65, 55,15, 65, 65, LineColor3);
        texture.Apply();
        double Tfinal9 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal9 = Tfinal9 - Tinicial9;
        print(Ttotal9);

        timer.Start();
        double Tinicial10 = timer.Elapsed.TotalMilliseconds;
        CuadradoADDA(200, 30, 30, 30, LineColor3);
        texture.Apply();
        double Tfinal10 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal10 = Tfinal10 - Tinicial10;
        print(Ttotal10);

        timer.Start();
        double Tinicial11 = timer.Elapsed.TotalMilliseconds;
        PentagonoADDA(Height / 1.2f, Width / 2.0f, sui, LineColor3);
        texture.Apply();
        double Tfinal11 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal11 = Tfinal11 - Tinicial11;
        print(Ttotal11);

        timer.Start();
        double Tinicial12 = timer.Elapsed.TotalMilliseconds;
        HexagonoADDA(Height / 2.0f, Width / 5.0f, sui, LineColor3);
        texture.Apply();
        double Tfinal12 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal12 = Tfinal12 - Tinicial12;
        print(Ttotal12);
    }

    public void Setup(float H, float W, Color Back)
    {
        texture = new Texture2D((int)H, (int)W);
        GetComponent<Renderer>().material.mainTexture = texture;
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                texture.SetPixel(x, (int)H - y - 1, Back);
            }
        }
    }
    public void ABasico(float x0, float y0, float x1, float y1, Color line)
    {
        if (x0 == x1)
        {
            if (y1 > y0)
            {
                for (int y = (int)y0; y <= y1; y++)
                {
                    texture.SetPixel((int)x0, y, line);
                }
            }
            else
            {
                for (int y = (int)y1; y <= y1; y++)
                {
                    texture.SetPixel((int)x0, y, line);
                }
            }
        }

        float m = (y1 - y0) / (x1 - x0);
        float b = y0 - m * x0;



        float yb = y0;
        if (x0 > x1)
        {

            for (int x = (int)x1; x <= x0; x++)
            {
                float y = m * x + b;
                if (Mathf.Abs(m) >= 1 && x > x1)
                {
                    ABasico(x, yb, x, y, line);
                }
                texture.SetPixel((int)x, (int)y, line);
                yb = y;
            }
        }
        else
        {
            for (int x = (int)x0; x <= x1; x++)
            {
                float y = m * x + b;
                if (Mathf.Abs(m) >= 1 && x > x0)
                {
                    ABasico(x, yb, x, y, line);
                }
                texture.SetPixel((int)x, (int)y, line);
                yb = y;
            }
        }
    }
    void Abressenham(int x, int y, int x2, int y2, Color color)
    {
        int w = x2 - x;
        int h = y2 - y;
        int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
        if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
        if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
        if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
        int longest = Mathf.Abs(w);
        int shortest = Mathf.Abs(h);
        if (!(longest > shortest))
        {
            longest = Mathf.Abs(h);
            shortest = Mathf.Abs(h);
            if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
            dx2 = 0;
        }
        int numerator = longest >> 1;
        for (int i = 0; i < longest; i++)
        {
            texture.SetPixel(x, y, color);
            numerator += shortest;
            if (!(numerator < longest))
            {
                numerator -= longest;
                x += dx1;
                y += dy1;
            }
            else
            {
                x += dx2;
                y += dy2;
            }
        }

    }
    public void ADDA(float x0, float y0, float x1, float y1, Color line)
    {
        if (x0 == x1)
        {
            if (y1 > y0)
            {
                for (int y = (int)y0; y >= y1; y++)
                {
                    texture.SetPixel((int)x0, y, line);
                }
            }
            else
            {
                for (int y = (int)y1; y <= y0; y++)
                {
                    texture.SetPixel((int)x0, y, line);
                }
            }
        }
        else
        {
            float Dx = (x1 - x0);
            float Dy = (y1 - y0);
            float m = (y1 - y0) / (x1 - x0);
            float k;
            if (Dx > Dy) { k = Dx; }
            else { k = Dy; }
            float y = y0;
            float x = x0;
            if (m <= 1)
            {
                for (int i = 0; i <= k; i++)
                {
                    y += m;
                    x += 1;
                    texture.SetPixel((int)x, (int)y, line);
                }
            }
            else
            {
                for (int i = 0; i <= k; i++)
                {
                    x += (1 / m);
                    y += 1;
                    texture.SetPixel((int)x, (int)y, line);
                }
            }
        }
    }

    //Metodo ABasico
    void TrianguloAB(float x1, float y1, float x2, float y2, float x3, float y3, Color line)
    {
        ABasico(x1, y1, x2, y2, line);
        ABasico(x2, y2, x3, y3, line);
        ABasico(x1, y1, x3, y3, line);
    }
    void CuadradoAB(float x, float y, float l1, float l2, Color line)
    {
        //punto 1
        float x1 = x;
        float y1 = y;
        //punto 2
        float x2 = x;
        float y2 = y + l2;
        //punto 3
        float x3 = x + l1;
        float y3 = y;
        //punto 4
        float x4 = x + l1;
        float y4 = y + l2;

        ABasico(x1, y1, x2, y2, line);
        ABasico(x2, y2, x4, y4, line);
        ABasico(x3, y3, x1, y1, line);
        ABasico(x3, y3, x4, y4, line);
    }
    void PentagonoAB(float x, float y, float r, Color line)
    {
        float a = (360 / 5.0f)*Mathf.Deg2Rad;
        //Punto 1
        float x1 = x;
        float y1 = y + r;
        //Punto 2
        float x2 = x - (r * Mathf.Sin(a));
        float y2 = y + (r * Mathf.Cos(a));
        //Punto 3
        float x3 = x + (r * Mathf.Sin(a));
        float y3 = y + (r * Mathf.Cos(a));
        //Punto 4
        float x4 = x + (r * Mathf.Sin (a*2));
        float y4 = y + (r * Mathf.Cos (a*2));
        //Punto 5
        float x5 = x - (r * Mathf.Sin (a*2));
        float y5 = y + (r * Mathf.Cos (a*2));

        ABasico(x1, y1, x2, y2, line);
        ABasico(x1, y1, x3, y3, line);
        ABasico(x2, y2, x5, y5, line);
        ABasico(x3, y3, x4, y4, line);
        ABasico(x5, y5, x4, y4, line);
    }
    void HexagonoAB(float x, float y, float r, Color line)
    {
        float a = (360 / 5.0f) * Mathf.Deg2Rad;
        //Punto 1
        float x1 = x;
        float y1 = y + r;
        //Punto 2
        float x2 = x - (r * Mathf.Sin(a));
        float y2 = y + (r * Mathf.Cos(a));
        //Punto 3
        float x3 = x + (r * Mathf.Sin(a));
        float y3 = y + (r * Mathf.Cos(a));
        //Punto 4
        float x4 = x + (r * Mathf.Sin(a * 2));
        float y4 = y + (r * Mathf.Cos(a * 2));
        //Punto 5
        float x5 = x - (r * Mathf.Sin(a * 2));
        float y5 = y + (r * Mathf.Cos(a * 2));
        //Punto 6
        float x6 = x;
        float y6 = y + (r * Mathf.Sin(a * 4));

        ABasico(x1, y1, x2, y2, line);
        ABasico(x1, y1, x3, y3, line);
        ABasico(x2, y2, x5, y5, line);
        ABasico(x3, y3, x4, y4, line);
        ABasico(x5, y5, x6, y6, line);
        ABasico(x6, y6, x4, y4, line);

    }

    //Metodo Abressenham
    void TrianguloA(int x1, int y1, int x2, int y2, int x3, int  y3, Color line)
    {
        Abressenham(x1, y1, x2, y2, line);
        Abressenham(x2, y2, x3, y3, line);
        Abressenham(x1, y1, x3, y3, line);
    }
    void CuadradoA(int x, int y, int l1, int l2, Color line)
    {
        //punto 1
        int x1 = x;
        int y1 = y;
        //punto 2
        int x2 = x;
        int y2 = y + l2;
        //punto 3
        int x3 = x + l1;
        int y3 = y;
        //punto 4
        int x4 = x + l1;
        int y4 = y + l2;

        Abressenham(x1, y1, x2, y2, line);
        Abressenham(x2, y2, x4, y4, line);
        Abressenham(x3, y3, x1, y1, line);
        Abressenham(x3, y3, x4, y4, line);
    }
    void PentagonoA(float x, float y, float r, Color line)
    {
        float a = (360 / 5.0f) * Mathf.Deg2Rad;
        //Punto 1
        float x1 = x;
        float y1 = y + r;
        //Punto 2
        float x2 = x - (r * Mathf.Sin(a));
        float y2 = y + (r * Mathf.Cos(a));
        //Punto 3
        float x3 = x + (r * Mathf.Sin(a));
        float y3 = y + (r * Mathf.Cos(a));
        //Punto 4
        float x4 = x + (r * Mathf.Sin(a * 1.5f));
        float y4 = y + (r * Mathf.Cos(a * 2));
        //Punto 5
        float x5 = x - (r * Mathf.Sin(a * 1.5f));
        float y5 = y + (r * Mathf.Cos(a * 2));

        Abressenham((int)x2, (int)y2, (int)x1, (int)y1, line);
        Abressenham((int)x1, (int)y1, (int)x3, (int)y3, line);
        Abressenham((int)x5, (int)y5, (int)x2, (int)y2, line);
        Abressenham((int)x4, (int)y4, (int)x3, (int)y3, line);
        Abressenham((int)x5, (int)y5, (int)x4, (int)y4, line);
    }
    void HexagonoA(float x, float y, float r, Color line)
    {
        float a = (360 / 5.0f) * Mathf.Deg2Rad;
        //Punto 1
        float x1 = x;
        float y1 = y + r;
        //Punto 2
        float x2 = x - (r * Mathf.Sin(a));
        float y2 = y + (r * Mathf.Cos(a));
        //Punto 3
        float x3 = x + (r * Mathf.Sin(a));
        float y3 = y + (r * Mathf.Cos(a));
        //Punto 4
        float x4 = x + (r * Mathf.Sin(a * 1.5f));
        float y4 = y + (r * Mathf.Cos(a * 1.6f));
        //Punto 5
        float x5 = x - (r * Mathf.Sin(a * 1.5f));
        float y5 = y + (r * Mathf.Cos(a * 1.6f));
        //Punto 6
        float x6 = x;
        float y6 = y + (r * Mathf.Sin(a * 4));

        Abressenham((int)x1, (int)y1, (int)x2, (int)y2, line);
        Abressenham((int)x1, (int)y1, (int)x3, (int)y3, line);
        Abressenham((int)x5, (int)y5, (int)x2, (int)y2, line);
        Abressenham((int)x4, (int)y4, (int)x3, (int)y3, line);
        Abressenham((int)x5, (int)y5, (int)x6, (int)y6, line);
        Abressenham((int)x6, (int)y6, (int)x4, (int)y4, line);

    }

    //Metodo ADDA
    void TrianguloADDA(int x1, int y1, int x2, int y2, int x3, int y3, Color line)
    {
        ADDA(x1, y1, x2, y2, line);
        ADDA(x2, y2, x3, y3, line);
        ADDA(x1, y1, x3, y3, line);
    }
    void CuadradoADDA(int x, int y, int l1, int l2, Color line)
    {
        //punto 1
        int x1 = x;
        int y1 = y;
        //punto 2
        int x2 = x;
        int y2 = y + l2;
        //punto 3
        int x3 = x + l1;
        int y3 = y;
        //punto 4
        int x4 = x + l1;
        int y4 = y + l2;

        ADDA(x2, y2, x1, y1, line);
        ADDA(x2, y2, x4, y4, line);
        ADDA(x1, y1, x3, y3, line);
        ADDA(x4, y4, x3, y3, line);

    }
    void PentagonoADDA(float x, float y, float r, Color line)
    {
        float a = (360 / 5.0f) * Mathf.Deg2Rad;
        //Punto 1
        float x1 = x;
        float y1 = y + r;
        //Punto 2
        float x2 = x - (r * Mathf.Sin(a));
        float y2 = y + (r * Mathf.Cos(a));
        //Punto 3
        float x3 = x + (r * Mathf.Sin(a));
        float y3 = y + (r * Mathf.Cos(a));
        //Punto 4
        float x4 = x + (r * Mathf.Sin(a * 2));
        float y4 = y + (r * Mathf.Cos(a * 2));
        //Punto 5
        float x5 = x - (r * Mathf.Sin(a * 2));
        float y5 = y + (r * Mathf.Cos(a * 2));

        ADDA((int)x2, (int)y2, (int)x1, (int)y1, line);
        ADDA((int)x1, (int)y1, (int)x3, (int)y3, line);
        ADDA((int)x2, (int)y2, (int)x5, (int)y5, line);
        ADDA((int)x4, (int)y4, (int)x3, (int)y3, line);
        ADDA((int)x5, (int)y5, (int)x4, (int)y4, line);
    }
    void HexagonoADDA(float x, float y, float r, Color line)
    {
        float a = (360 / 5.0f) * Mathf.Deg2Rad;
        //Punto 1
        float x1 = x;
        float y1 = y + r;
        //Punto 2
        float x2 = x - (r * Mathf.Sin(a));
        float y2 = y + (r * Mathf.Cos(a));
        //Punto 3
        float x3 = x + (r * Mathf.Sin(a));
        float y3 = y + (r * Mathf.Cos(a));
        //Punto 4
        float x4 = x + (r * Mathf.Sin(a * 1.5f));
        float y4 = y + (r * Mathf.Cos(a * 1.6f));
        //Punto 5
        float x5 = x - (r * Mathf.Sin(a * 1.5f));
        float y5 = y + (r * Mathf.Cos(a * 1.6f));
        //Punto 6
        float x6 = x;
        float y6 = y + (r * Mathf.Sin(a * 4));

        ADDA((int)x2, (int)y2, (int)x1, (int)y1, line);
        ADDA((int)x1, (int)y1, (int)x3, (int)y3, line);
        ADDA((int)x2, (int)y2, (int)x5, (int)y5, line);
        ADDA((int)x3, (int)y3, (int)x4, (int)y4, line);
        ADDA((int)x5, (int)y5, (int)x6, (int)y6, line);
        ADDA((int)x6, (int)y6, (int)x4, (int)y4, line);

    }

    public void SaveTexture()
    {
        byte[] bytes = texture.EncodeToPNG();
        var dirPath = Application.dataPath + "/RenderOutput";
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }
        System.IO.File.WriteAllBytes(dirPath + "/R_" + Random.Range(0, 100000) + ".png", bytes);
    }
}
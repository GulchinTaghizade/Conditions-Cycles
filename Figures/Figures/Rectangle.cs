﻿using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace FigureApp
{
    public class Rectangle:Figure
    {
        double SideA, SideB;
        public Rectangle(List<Point> points):base(points)
        {
            
            SideA = Points[0].CoordinateX - Points[1].CoordinateX;
            SideB = Points[0].CoordinateY - Points[3].CoordinateY;
        }

        public override void FindArea()
        {
            this.Area= SideA * SideB;
        }
        

        public override void FindPerimeter()
        {
            this.Perimeter= 2 * (SideA + SideB);
        }

        public override void MoveFigure(double x, double y)
        {
            foreach (var p in Points)
            {
                p.CoordinateX += x;
                p.CoordinateY += y;
            }
        }

        public override void RotateFigure(double degree)
        {
            foreach (var p in Points)
            {
                p.CoordinateX = p.CoordinateX * Math.Cos(degree) - p.CoordinateY * Math.Sin(degree);
                p.CoordinateY = p.CoordinateY * Math.Cos(degree) + p.CoordinateX * Math.Sin(degree);
            }
        }

        public override void ScaleFigure(double scale)
        {
            foreach (var p in Points)
            {
                p.CoordinateX = Center.CoordinateX - scale * (Center.CoordinateX - p.CoordinateX);
                p.CoordinateY = Center.CoordinateY - scale * (Center.CoordinateY - p.CoordinateY);
            }
            this.FindPerimeter();
            this.FindArea();
        }

        public override void FindCenter()
        {
            double sumX = 0, sumY = 0;
            foreach (var p in Points)
            {
                sumX += p.CoordinateX;
                sumY += p.CoordinateY;
            }
            this.Center = new Point(sumX / 4, sumY / 4);
        }
        public override string ToString()
        {
            return $"{nameof(Rectangle)}\nArea:{Area}\nPerimeter:{Perimeter}";
        }
    }
}


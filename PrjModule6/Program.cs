using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using FigureMath.Abstractions;
using FigureMath.Exceptions;
using FigureMath.Figures;

namespace PrjModule6
{
    public static class Program
    {
        private static void Main()
        {
            //Dot in console
            var customCulture = (CultureInfo) Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;
            //
            while (true)
            {
                Console.WriteLine("Choose your figure(circle|quadrangle|triangle|deserialize)");
                var figureType = Console.ReadLine();
                switch (figureType)
                {
                    case "circle":
                        GetCircleMethods();
                        break;
                    case "quadrangle":
                        GetQuadrangleMethods();
                        break;
                    case "triangle":
                        GetTriangleMethods();
                        break;
                    case "deserialize":
                        var formatter = new BinaryFormatter();
                        if (File.Exists("Figure.dat"))
                        {
                            using var fs = new FileStream("Figure.dat", FileMode.OpenOrCreate);
                            var figureDeserialize = formatter.Deserialize(fs);

                            if (figureDeserialize.GetType().Name == "Circle")
                            {
                                var circle = (Circle) figureDeserialize;
                                Console.WriteLine("Deserializes object is Circle");
                                GetCircleMethods(circle.Radius);
                            }

                            var baseType = figureDeserialize.GetType().BaseType?.Name;
                            switch (baseType)
                            {
                                case "Quadrangle":
                                    var quadrangle = (Quadrangle) figureDeserialize;
                                    Console.WriteLine("Deserializes object is Quadrangle");
                                    GetQuadrangleMethods(
                                        new List<double[]>
                                        {
                                            quadrangle.AVertex, quadrangle.BVertex, quadrangle.CVertex,
                                            quadrangle.DVertex
                                        }, figureDeserialize.GetType().Name);
                                    break;
                                case "Triangle":
                                    var triangle = (Triangle) figureDeserialize;
                                    Console.WriteLine("Deserializes object is Triangle");
                                    GetTriangleMethods(
                                        new List<double[]> {triangle.AVertex, triangle.BVertex, triangle.CVertex},
                                        figureDeserialize.GetType().Name);
                                    break;
                                default:
                                    ConsoleWithColor("\nWrong base type\n", ConsoleColor.Red);
                                    break;
                            }
                        }
                        else
                        {
                            ConsoleWithColor("\nThere no serialized objects\n", ConsoleColor.Red);
                            continue;
                        }

                        break;
                    default:
                        ConsoleWithColor("\nThere no such variant\n", ConsoleColor.Red);
                        break;
                }

                Console.WriteLine("Press 'e' for exit or enter for continue");

                var exitState = Console.ReadKey();
                switch (exitState.Key)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        continue;
                    case ConsoleKey.E:
                        return;
                    default:
                        return;
                }
            }
        }

        private static void GetCircleMethods(double radius = 0)
        {
            while (true)
            {
                if (radius == 0) Console.Write("Write your circle radius: ");

                var circleRadius = radius == 0 ? Console.ReadLine() : radius.ToString(CultureInfo.CurrentCulture);
                if (double.TryParse(circleRadius, out radius))
                {
                    Circle circle;
                    try
                    {
                        circle = new Circle(radius);
                    }
                    catch (FigureMathException e)
                    {
                        ConsoleWithColor(e.Message, ConsoleColor.Red);
                        continue;
                    }

                    while (true)
                    {
                        Console.WriteLine("\nChose method \n" +
                                          "GetArea-1\n" +
                                          "GetPerimeter-2\n" +
                                          "GetSide - 3\n" +
                                          "Serialize object-4\n");

                        var circleMethod = Console.ReadLine();
                        try
                        {
                            switch (circleMethod)
                            {
                                case "1":
                                    Console.WriteLine(circle.GetArea());
                                    break;
                                case "2":
                                    Console.WriteLine(circle.GetPerimeter());
                                    break;
                                case "3":
                                    circle.GetSides().ToList().ForEach(Console.WriteLine);
                                    break;
                                case "4":
                                    var formatter = new BinaryFormatter();
                                    using (var fs = new FileStream("Figure.dat", FileMode.Create))
                                    {
                                        formatter.Serialize(fs, circle);

                                        Console.WriteLine("Object serialized");
                                    }

                                    break;
                                default:
                                    ConsoleWithColor("\nThere no such method\n", ConsoleColor.Red);
                                    break;
                            }
                        }
                        catch (FigureMathException e)
                        {
                            ConsoleWithColor(e.Message, ConsoleColor.Red);
                            continue;
                        }


                        Console.WriteLine("Press 'e' for exit or enter for continue");

                        var exitState = Console.ReadKey();
                        switch (exitState.Key)
                        {
                            case ConsoleKey.Enter:
                                continue;
                            case ConsoleKey.E:
                                return;
                            default:
                                return;
                        }
                    }
                }

                ConsoleWithColor("\nWrong radius please try again\n", ConsoleColor.Red);
            }
        }

        private static void GetQuadrangleMethods(List<double[]> vertexes = null, string quadrangleType = null)
        {
            while (true)
            {
                if (vertexes == null || vertexes.Count == 0)
                {
                    Console.Write("\nWrite your vertexes with a space(Ex: 5,7 4.4,5 7,6 1.4,8): ");

                    vertexes = new List<double[]>();
                    try
                    {
                        var tmpStringParseList = Console.ReadLine()?.Split(' ').ToList();
                        var vertexes1 = vertexes;
                        tmpStringParseList?.ForEach(
                            x => { vertexes1.Add(x.Split(",").Select(double.Parse).ToArray()); });
                    }
                    catch
                    {
                        ConsoleWithColor("\nWrong array please try again\n", ConsoleColor.Red);
                        vertexes.Clear();
                        continue;
                    }
                }


                if (vertexes.Count == 4 || vertexes.Count == 0)
                {
                    Quadrangle quadrangle = null;

                    try
                    {
                        if (quadrangleType == null)
                        {
                            Console.WriteLine("\nChose quadrangle \n" +
                                              "Parallelogram - 1\n" +
                                              "Rectangle - 2\n" +
                                              "Square - 3\n" +
                                              "Rhombus - 4\n" +
                                              "Trapeze - 5\n");
                            quadrangleType = Console.ReadLine();
                        }


                        switch (quadrangleType)
                        {
                            case "Parallelogram":
                            case "1":
                                quadrangle = new Parallelogram(vertexes[0], vertexes[1], vertexes[2], vertexes[3]);
                                break;
                            case "Rectangle":
                            case "2":
                                quadrangle = new Rectangle(vertexes[0], vertexes[1], vertexes[2], vertexes[3]);
                                break;
                            case "Square":
                            case "3":
                                quadrangle = new Square(vertexes[0], vertexes[1], vertexes[2], vertexes[3]);
                                break;
                            case "Rhombus":
                            case "4":
                                quadrangle = new Rhombus(vertexes[0], vertexes[1], vertexes[2], vertexes[3]);
                                break;
                            case "Trapeze":
                            case "5":
                                quadrangle = new Trapeze(vertexes[0], vertexes[1], vertexes[2], vertexes[3]);
                                break;
                            default:
                                ConsoleWithColor("\nThere no such Figure\n", ConsoleColor.Red);
                                quadrangleType = null;
                                break;
                        }
                    }
                    catch (FigureMathException e)
                    {
                        ConsoleWithColor(e.Message, ConsoleColor.Red);
                        vertexes.Clear();
                        continue;
                    }

                    while (true)
                    {
                        Console.WriteLine("\nChose method \n" +
                                          "GetArea-1\n" +
                                          "GetPerimeter-2\n" +
                                          "GetSides-3\n" +
                                          "GetDiagonals-4\n" +
                                          "GetAngles-5\n" +
                                          "GetCircumscribedCircleRadius-6\n" +
                                          "GetInscribedCircleRadius-7\n" +
                                          "Serialize object-8\n");

                        var circleMethod = Console.ReadLine();
                        try
                        {
                            switch (circleMethod)
                            {
                                case "1":
                                    Console.WriteLine(quadrangle?.GetArea());
                                    break;
                                case "2":
                                    Console.WriteLine(quadrangle?.GetPerimeter());
                                    break;
                                case "3":
                                    quadrangle?.GetSides().ToList().ForEach(Console.WriteLine);
                                    break;
                                case "4":
                                    quadrangle?.GetDiagonals().ToList().ForEach(Console.WriteLine);
                                    break;
                                case "5":
                                    quadrangle?.GetAngles().ToList().ForEach(Console.WriteLine);
                                    break;
                                case "6":
                                    Console.WriteLine(quadrangle?.GetCircumscribedCircleRadius());
                                    break;
                                case "7":
                                    Console.WriteLine(quadrangle?.GetInscribedCircleRadius());
                                    break;
                                case "8":
                                    var formatter = new BinaryFormatter();
                                    using (var fs = new FileStream("Figure.dat", FileMode.Create))
                                    {
                                        formatter.Serialize(fs, quadrangle ?? throw new InvalidOperationException());

                                        Console.WriteLine("Object serialized");
                                    }

                                    break;
                                default:
                                    ConsoleWithColor("\nThere no such method\n", ConsoleColor.Red);
                                    break;
                            }
                        }
                        catch (FigureMathException e)
                        {
                            ConsoleWithColor(e.Message, ConsoleColor.Red);
                            vertexes.Clear();
                            continue;
                        }


                        Console.WriteLine("Press 'e' for exit or enter for continue");

                        var exitState = Console.ReadKey();
                        switch (exitState.Key)
                        {
                            case ConsoleKey.Enter:
                                continue;
                            case ConsoleKey.E:
                                return;
                            default:
                                return;
                        }
                    }
                }

                ConsoleWithColor("\nWrong vertexes\n", ConsoleColor.Red);
                vertexes.Clear();
            }
        }

        private static void GetTriangleMethods(List<double[]> vertexes = null, string triangleType = null)
        {
            while (true)
            {
                if (vertexes == null || vertexes.Count == 0)
                {
                    Console.Write("\nWrite your vertexes with a space(Ex: 5,7 4.4,5 1.4,8): ");

                    vertexes = new List<double[]>();
                    try
                    {
                        var tmpStringParseList = Console.ReadLine()?.Split(' ').ToList();
                        var vertexes1 = vertexes;
                        tmpStringParseList?.ForEach(
                            x => { vertexes1.Add(x.Split(",").Select(double.Parse).ToArray()); });
                    }
                    catch
                    {
                        ConsoleWithColor("\nWrong array please try again\n", ConsoleColor.Red);
                        vertexes.Clear();
                        continue;
                    }
                }


                if (vertexes.Count == 3 || vertexes.Count == 0)
                {
                    Triangle triangle = null;

                    try
                    {
                        if (triangleType == null)
                        {
                            Console.WriteLine("\nChose triangle \n" +
                                              "ArbitraryTriangle - 1\n" +
                                              "EquilateralTriangle - 2\n" +
                                              "IsoscelesTriangle - 3\n" +
                                              "RightTriangle - 4\n");

                            triangleType = Console.ReadLine();
                        }

                        switch (triangleType)
                        {
                            case "ArbitraryTriangle":
                            case "1":
                                triangle = new ArbitraryTriangle(vertexes[0], vertexes[1], vertexes[2]);
                                break;
                            case "EquilateralTriangle":
                            case "2":
                                triangle = new EquilateralTriangle(vertexes[0], vertexes[1], vertexes[2]);
                                break;
                            case "IsoscelesTriangle":
                            case "3":
                                triangle = new IsoscelesTriangle(vertexes[0], vertexes[1], vertexes[2]);
                                break;
                            case "RightTriangle":
                            case "4":
                                triangle = new RightTriangle(vertexes[0], vertexes[1], vertexes[2]);
                                break;
                            default:
                                ConsoleWithColor("\nThere no such Figure\n", ConsoleColor.Red);
                                triangleType = null;
                                break;
                        }
                    }
                    catch (FigureMathException e)
                    {
                        ConsoleWithColor(e.Message, ConsoleColor.Red);
                        vertexes.Clear();
                        continue;
                    }

                    while (true)
                    {
                        Console.WriteLine("\nChose method \n" +
                                          "GetArea-1\n" +
                                          "GetPerimeter-2\n" +
                                          "GetSides-3\n" +
                                          "GetHeight-4\n" +
                                          "GetMedian-5\n" +
                                          "GetBisector-6\n" +
                                          "GetAngles-7\n" +
                                          "GetCircumscribedCircleRadius-8\n" +
                                          "GetInscribedCircleRadius-9\n" +
                                          "Serialize object-10\n");

                        var circleMethod = Console.ReadLine();
                        try
                        {
                            switch (circleMethod)
                            {
                                case "1":
                                    Console.WriteLine(triangle?.GetArea());
                                    break;
                                case "2":
                                    Console.WriteLine(triangle?.GetPerimeter());
                                    break;
                                case "3":
                                    triangle?.GetSides().ToList().ForEach(Console.WriteLine);
                                    break;
                                case "4":
                                    triangle?.GetHeight().ToList().ForEach(Console.WriteLine);
                                    break;
                                case "5":
                                    triangle?.GetMedian().ToList().ForEach(Console.WriteLine);
                                    break;
                                case "6":
                                    triangle?.GetBisector().ToList().ForEach(Console.WriteLine);
                                    break;
                                case "7":
                                    triangle?.GetAngles().ToList().ForEach(Console.WriteLine);
                                    break;
                                case "8":
                                    Console.WriteLine(triangle?.GetCircumscribedCircleRadius());
                                    break;
                                case "9":
                                    Console.WriteLine(triangle?.GetInscribedCircleRadius());
                                    break;
                                case "10":
                                    var formatter = new BinaryFormatter();
                                    using (var fs = new FileStream("Figure.dat", FileMode.Create))
                                    {
                                        formatter.Serialize(fs, triangle ?? throw new InvalidOperationException());

                                        Console.WriteLine("Object serialized");
                                    }

                                    break;
                                default:
                                    ConsoleWithColor("\nThere no such method\n", ConsoleColor.Red);
                                    break;
                            }
                        }
                        catch (FigureMathException e)
                        {
                            ConsoleWithColor(e.Message, ConsoleColor.Red);
                            vertexes.Clear();
                            continue;
                        }

                        Console.WriteLine("Press 'e' for exit or enter for continue");

                        var exitState = Console.ReadKey();
                        switch (exitState.Key)
                        {
                            case ConsoleKey.Enter:
                                continue;
                            case ConsoleKey.E:
                                return;
                            default:
                                return;
                        }
                    }
                }

                ConsoleWithColor("\nWrong vertexes\n", ConsoleColor.Red);
                vertexes.Clear();
            }
        }

        private static void ConsoleWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
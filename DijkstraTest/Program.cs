﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperNet.Framework.Domain;
using SuperNet.Util.Alogrithm.SingleSourceShortestPaths;

namespace DijkstraTest
{
    class Program
    {
        static void Main(string[] args) {
            var map = new Map();

            var v1 = new Vertex { VertexName = "v1" };
            var v2 = new Vertex { VertexName = "v2" };
            var v3 = new Vertex { VertexName = "v3" };
            var v4 = new Vertex { VertexName = "v4" };
            var v5 = new Vertex { VertexName = "v5" };
            var v6 = new Vertex { VertexName = "v6" };
            var v7 = new Vertex { VertexName = "v7" };

            var e12 = new Edge(v1, v2, 2);
            var e23 = new Edge(v2, v3, 1);
            var e15 = new Edge(v1, v5, 4);
            var e56 = new Edge(v5, v6, 3);
            var e54 = new Edge(v5, v4, 3);
            var e64 = new Edge(v6, v4, 1);
            var e27 = new Edge(v2, v7, 2);
            var e74 = new Edge(v7, v4, 2);

            map.Add(e12);
            map.Add(e23);
            map.Add(e15);
            map.Add(e56);
            map.Add(e54);
            map.Add(e64);
            map.Add(e27);
            map.Add(e74);

            var dijkstra = new Dijkstra(map, v1);
            var result = dijkstra.ExecuteDijkstra();

            Console.ReadLine();
        }
    }
}

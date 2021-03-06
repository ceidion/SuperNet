﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToExcel;
using System.IO;
using SuperNet.Framework.Domain;

namespace SuperNet.Framework.Source
{
    public class ExcelMapDataSource : MapDataSourceBase
    {
        private string _excelPath;

        public ExcelMapDataSource(string path) {
            if (!File.Exists(path)) {
                throw new ArgumentException("File not Exist.");
            }
            _excelPath = path;
        }

        public override Map ImportMap() {
            var rawData = ReadAll(_excelPath);

            var map = new Map();
            foreach (var line in rawData) {
                var edge = GenerateEdge(line);
                map.Add(edge);
            }

            return map;
        }

        private IList<string[]> ReadAll(string path) {
            var excel = new ExcelQueryFactory(path);
            var worksheet = excel.WorksheetNoHeader(0);
            if (worksheet != null) {
                var data = from row in worksheet
                           where row[0] != String.Empty ||
                                 row[1] != String.Empty
                           select new string[] {
                                row[0].Value.ToString(),
                                row[1].Value.ToString()
                           };
                return data.ToList();
            }
            return new List<string[]>();
        }
    }
}

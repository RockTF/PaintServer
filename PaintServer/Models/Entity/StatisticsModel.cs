using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Entity

{
    public class StatisticsModel
    {
        public int Id { get; set; }

        [ForeignKey("PersonModel")]
        public int PersonId { get; set; }
        public DateTime LastActivity { get; set; }
        public DateTime CreatedAt { get; set; }
        public int FullPictureSize { get; set; }
        public string FiguresCountString { get; set; }
        public PersonModel PersonModel { get; set; }

        [NotMapped]
        public List <KeyValuePair<string, int>> FiguresCount
        {
            get { return JsonConvert.DeserializeObject<List<KeyValuePair<string, int>>>(FiguresCountString); }
            set { FiguresCountString = JsonConvert.SerializeObject(value); }
        }
        public string FavoriteFigures { get; set; }

        public StatisticsModel()
        {
            var figuresCount = new List<KeyValuePair<string, int>>();
            figuresCount.Add(new KeyValuePair<string, int>("Curve", 0));
            figuresCount.Add(new KeyValuePair<string, int>("Dot", 0));
            figuresCount.Add(new KeyValuePair<string, int>("Ellipse", 0));
            figuresCount.Add(new KeyValuePair<string, int>("Line", 0));
            figuresCount.Add(new KeyValuePair<string, int>("Triangle", 0));
            figuresCount.Add(new KeyValuePair<string, int>("Polygon", 0));
            figuresCount.Add(new KeyValuePair<string, int>("Rectangle", 0));
            figuresCount.Add(new KeyValuePair<string, int>("SmoothCurve", 0));
            figuresCount.Add(new KeyValuePair<string, int>("RoundedRectangle", 0));

            CreatedAt = DateTime.Now;

        }

        public void FillFigures(Dictionary<string, int> values)
        {
            for (int i = 0; i < FiguresCount.Count; i++)
            {
                var asd = values.GetValueOrDefault(FiguresCount[i].Key);
                FiguresCount[i] = new KeyValuePair<string, int>(FiguresCount[i].Key, FiguresCount[i].Value + asd);
            }
        }

        public void FillFavoriteFigures()
        {
            var updatedFavoriteFigures = new List<string>();

            for (int i = 0; i < FiguresCount.Count; i++)
            {
                if (FiguresCount[i].Value >= 5) updatedFavoriteFigures.Add(FiguresCount[i].Key);
            }

            FavoriteFigures = String.Join(",",updatedFavoriteFigures);
        }
    }
}

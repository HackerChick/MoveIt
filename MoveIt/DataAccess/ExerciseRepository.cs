using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using MoveIt.Model;

namespace MoveIt.DataAccess
{
    public class ExerciseRepository
    {
        private const string DATA_FILE = "Data/Exercises.xml";
        private readonly List<Exercise> exercises;

        private static ExerciseRepository _singletonInstance;
        public static ExerciseRepository Default { get { return _singletonInstance ?? (_singletonInstance = new ExerciseRepository()); } }

        ExerciseRepository()
        {
            exercises = LoadExercises(DATA_FILE);
        }

        public List<Exercise> GetExercises()
        {
            return new List<Exercise>(exercises);
        }

        public Exercise GetExercise(int id)
        {
            return exercises[id];
        }

        private static List<Exercise> LoadExercises(string dataFile)
        {
            XElement root = XElement.Load(dataFile);
            int exId = 0;
            return (from e in root.Elements("exercise")
                    select new Exercise()
                               {
                                   Id = exId++,
                                   Name = (string)e.Attribute("Name"),
                                   Url = (string)e.Attribute("Url"),
                                   Picture = (string)e.Attribute("Picture")
                               }).ToList();
        }
    }

    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}

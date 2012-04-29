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
    public class MoveInstructionRepository
    {
        private const string DATA_FILE = "Data/MoveInstructions.xml";
        private readonly List<JustMoveInstruction> instructions;

        private static MoveInstructionRepository _singletonInstance;
        public static MoveInstructionRepository Default { get { return _singletonInstance ?? (_singletonInstance = new MoveInstructionRepository()); } }

        MoveInstructionRepository()
        {
            instructions = LoadInstructions(DATA_FILE);
        }

        public List<JustMoveInstruction> GetInstructions()
        {
            return new List<JustMoveInstruction>(instructions);
        }

        private static List<JustMoveInstruction> LoadInstructions(string dataFile)
        {
            XElement root = XElement.Load(dataFile);
            return (from e in root.Elements("instruction")
                    select new JustMoveInstruction()
                               {
                                   Text = (string)e.Attribute("Text")
                               }).ToList();
        }
    }
}

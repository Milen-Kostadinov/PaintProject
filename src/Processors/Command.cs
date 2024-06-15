using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Processors
{
    public class Command
    {
        private CommandsEnum command;
        public CommandsEnum _command { get { return command; } set { command = value; } }
        private Shape shape;
        public Shape _shape { get { return shape; } set { shape = value; } }
        private Shape shapeChanges;
        public Shape _shapeChanges { get { return shapeChanges; } set { shapeChanges = value; } }
        public Command(Shape shape, Shape shapeChanges, CommandsEnum command)
        { 
            this.shape = shape;
            this.shapeChanges = shapeChanges;
            this.command = command;
        }
    }
}

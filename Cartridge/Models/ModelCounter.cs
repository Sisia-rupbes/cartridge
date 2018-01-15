using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cartridge.Models
{
    public class ModelCounter
    {
        private p000049 _model;
        public p000049 Model
        {
            get { return _model; }
            set { this._model = value; }
        }
        private int? _count;
        public int? Count
        {
            get { return _count; }
            set { this._count = value; }
        }
    }
}
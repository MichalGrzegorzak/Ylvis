using System;
using System.Collections.Generic;
using ToolCut.Core.Domain;

namespace ToolCut.Core.Domain
{
    [Serializable]
    public class Tool : DomainObject<Guid>
    {
        public const string ColRgh = "rgh_id";
        public const string ColSemiFin = "semiFin_id";
        public const string ColFin = "fin_id";
        public const string ColFineFin = "fineFin_id";

        #region Constructor
        public Tool()
        {
        }
        #endregion

        public virtual String Name      { get; set; }
        public virtual decimal Diameter { get; set; }
        public virtual Int32 Sfm        { get; set; }

        public virtual decimal Milling2 { get; set; }
        public virtual decimal Milling4 { get; set; }
        public virtual decimal Milling6 { get; set; }

        public virtual decimal CrbDrill { get; set; }
        public virtual decimal HssDrill { get; set; }
        public virtual decimal Reamer   { get; set; }
        public virtual Int32 Flut      { get; set; }

        public virtual Tool Rgh         { get; set; }
        public virtual Tool SemiFin     { get; set; }
        public virtual Tool Fin         { get; set; }
        public virtual Tool FineFin     { get; set; }

        #region Methods
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        #endregion

     }
}

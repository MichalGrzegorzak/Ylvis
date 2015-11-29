using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;

namespace Tests
{
    public class StealthSettings : DefaultSettings
    {
        public StealthSettings()
        {
            SetDefaults();
        }

        public override void Reset()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            base.Reset();
            AutoMoveMousePointerToTopLeft = false;
            HighLightElement = false;
            MakeNewIeInstanceVisible = false;
        }
    }
}

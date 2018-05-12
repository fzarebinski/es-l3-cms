using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace es_l3_cms
{
    class Decision
    {
        private string question;
        private int trueSkip;
        private int falseSkip;

        public Decision(string question, int trueSkip, int falseSkip)
        {
            this.question = question;
            this.trueSkip = trueSkip;
            this.falseSkip = falseSkip;
        }

        public string GetQuestion()
        {
            return this.question;
        }

        public int GetTrue()
        {
            return this.trueSkip;
        }

        public int GetFalse()
        {
            return this.falseSkip;
        }

        public int GetSkip(bool decision)
        {
            return (decision ? this.trueSkip : this.falseSkip);
        }
    }
}

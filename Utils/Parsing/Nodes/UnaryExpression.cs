﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.Parsing.Nodes
{
    public class UnaryExpression : Expression
    {
        public UnaryExpression(SyntaxKind kind, int pos, int end) : base(kind, pos, end)
        {
        }
    }
}

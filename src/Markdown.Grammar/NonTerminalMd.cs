using System;
using Irony.Parsing;

namespace Markdown.Grammar
{
    public class NonTerminalMd : NonTerminal
    {
        public NonTerminalMd(string name) : base(name)
        {
        }
        public NonTerminalMd(string name, Type nodeType) : base(name,  nodeType)
        {
            AstConfig.DefaultNodeCreator = () =>  Activator.CreateInstance(nodeType);
        }
    }
}
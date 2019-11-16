using System;
using System.Linq;
using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace Markdown.Grammar
{
    public class BaseAst : AstNode
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Type previousNodeType = null;
            ListContainer lastContainer = null;
            treeNode.ChildNodes.Select(x =>
            {
                var abc = x.AstNode as BaseAst;
                var toReturn = abc;
                if (abc is ListItemAst li)
                    toReturn = AddToContainer(li, previousNodeType,ref lastContainer);
                previousNodeType = abc?.GetType();
                    return toReturn;
            }).Where(x => x != null).ToList().ForEach(ChildNodes.Add);
        }

        private BaseAst AddToContainer(ListItemAst li, Type previousNodeType,ref  ListContainer lastContainer)
        {
            var listitem = li.GetType();
            if (previousNodeType == listitem)
            {
                lastContainer.ChildNodes.Add(li);
                return null;
            }else
            {
                li.Container = new ListContainer();
                li.Container.ChildNodes.Add(li);
                lastContainer = li.Container;
                return li.Container;
            }
        }

        public virtual string StartTag { get; } = "";
        public string EndTag => StartTag.Replace("<", @"</");
    }
}
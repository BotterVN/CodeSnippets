using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Algorithms.AStar
{
    public interface INode<T>
    {
        T Content { get; set; }
        INode<T> Parent { get; }
        int Distance { get; set; }
        int Heuristic { get; set; }
        bool IsChecked { get; set; }

        List<INode<T>> GenerateNextNodes();
        bool IsEqual(INode<T> node);
    }
}

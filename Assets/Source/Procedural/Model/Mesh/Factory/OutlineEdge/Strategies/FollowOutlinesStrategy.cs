using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace Procedural.Model
{
    public class FollowOutlinesStrategy : IOutlineEdgeFactory
    {
        public IEnumerable<Edge> build(IMesh mesh)
        {
            Reset();
            return mesh
                .ExternalVertices
                .WhereNot(checkedVertices.Contains)
                .Aggregate(new List<Edge>(), NextOutlineEdge);
        }

        private List<Edge> NextOutlineEdge(List<Edge> edges, Vertex vertex)
        {
            try
            {
                var outlineVertex = GetConnectedOutlineVertexFor(vertex);
                checkedVertices.Add(outlineVertex);

                edges.Add(new Edge(vertex));
                
                FollowOutline(edges, outlineVertex);
                
                edges.Last().VertexB = vertex;
                
                return edges;
            }
            catch (InvalidOperationException)
            {
                return edges;
            }
        }

        private void FollowOutline(ICollection<Edge> edges, Vertex vertex)
        {
            try
            {
                edges.Last().VertexB = vertex;

                var outlineVertex = GetConnectedOutlineVertexFor(vertex);
                checkedVertices.Add(outlineVertex);

                edges.Add(new Edge(vertex));
                FollowOutline(edges, outlineVertex);
            }
            catch (InvalidOperationException)
            {
            }
        }
        
        private Vertex GetConnectedOutlineVertexFor(Vertex outlineVertex)
        {
            return outlineVertex
                .ExternalVertices
                .WhereNot(vertex => vertex.Equals(outlineVertex))
                .WhereNot(checkedVertices.Contains)
                .First(vertex => vertex.makeUpOutlineEdge(outlineVertex));
        }

        private void Reset()
        {
            checkedVertices = new List<Vertex>();
        }
        
        private IList<Vertex> checkedVertices;
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace MVCExample
{
    public sealed class CompositeMove : IMoveToPoint
    {
        private List<IMoveToPoint> _moves = new List<IMoveToPoint>();

        public void AddUnit(IMoveToPoint unit)
        {
            _moves.Add(unit);
        }

        public void RemoveUnit(IMoveToPoint unit)
        {
            _moves.Remove(unit);
        }


        public void Move(Vector3 point)
        {
            for (var i = 0; i < _moves.Count; i++)
            {
                _moves[i].Move(point);
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace MVCExample
{
    public sealed class CompositeMove : IMoveToPoint
    {
        private List<IMoveToPoint> _moves = new List<IMoveToPoint>();

        public bool CanMove {get;set;}

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
            bool anyImmobilized = false;

            for (var i = 0; i < _moves.Count; i++)
            {
                if(!_moves[i].CanMove)
                {
                    anyImmobilized = true;
                    continue;
                }

                _moves[i].Move(point);
            }

            if(anyImmobilized)
            {
                RemoveImmobilizedMoves();
            }
        }

        private void RemoveImmobilizedMoves()
        {
            _moves.RemoveAll(move => !move.CanMove);
        }

        public List<IMoveToPoint> GetEnemiesList()
        {
            return _moves;
        }
    }
}

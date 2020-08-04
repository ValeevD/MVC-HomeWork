using UnityEngine;

namespace MVCExample
{
    public interface IPlayerFactory
    {
        PlayerProvider CreatePlayer();
    }
}

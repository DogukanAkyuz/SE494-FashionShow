using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace FashionShowServer
{
    public class PlayerPos
    {
        private Vector3 _position;
        private bool _isAvailable;

        public PlayerPos(Vector3 position, bool isAvailable)
        {
            _position = position;
            _isAvailable = isAvailable;
        }

        public Vector3 GetPos()
        {
            return _position;
        }

        public bool GetAvailability()
        {
            return _isAvailable;
        }

        public void SetAvailability(bool set)
        {
            _isAvailable = set;
        }
    }

    // The following script must be placed in all scenes attached to a GameObject named as "InstantiatePlayer" in order to work...
    public static class InstantiatePlayer
    {
        private static PlayerPos[] _playerPosList;
        private static int _playerCt;

        public static void Init(int playerCt = 10)
        {
            _playerCt = playerCt;
            _playerPosList = new PlayerPos[]{
                new PlayerPos(new Vector3(3.372074f, -2.64f, -7.316802f), true),
                new PlayerPos(new Vector3(3.372074f, -2.64f, 8.183192f), true),
                new PlayerPos(new Vector3(6.872074f, -2.64f, -7.316802f), true),
                new PlayerPos(new Vector3(6.872074f, -2.64f, 8.183192f), true),
                new PlayerPos(new Vector3(10.37207f, -2.64f, -7.316802f), true),
                new PlayerPos(new Vector3(10.37207f, -2.64f, 8.183192f), true),
                new PlayerPos(new Vector3(13.87207f, -2.64f, -7.316802f), true),
                new PlayerPos(new Vector3(13.87207f, -2.64f, 8.183192f), true),
                new PlayerPos(new Vector3(17.87207f, -2.64f, -7.316802f), true),
                new PlayerPos(new Vector3(17.87207f, -2.64f, 8.183192f), true),
         };
        }

        public static Vector3 GetPosition()
        {
            for (int i = 0; i < _playerCt; i++)
            {
                if (_playerPosList[i].GetAvailability())
                {
                    _playerPosList[i].SetAvailability(false);
                    return _playerPosList[i].GetPos();
                }
            }
            Console.WriteLine("There are no spaces left!");
            throw new InvalidOperationException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace FashionShowServer
{
    class Player
    {
        public int id;
        public string username;
        public string avatarData;

        public Vector3 position;
        public Quaternion rotation;

        public Player(int _id, string _username, string _avatarData, Vector3 _spawnPosition)
        {
            id = _id;
            username = _username;
            avatarData = _avatarData;
            position = _spawnPosition;
            rotation = Quaternion.Identity;
        }
    }
}

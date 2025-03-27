using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    class GamePlayManager
    {
        private Map _map;
        private PC _player;
        private Coord _playerCoord; // 플레이어 좌표 지정하고 활용해도됨

        public void PlayGame() {
            InitializedLevel(); // 초기화
            GameWorkFlow(); // 게임 흐름 진행
        }

        private void InitializedLevel() { 
            CreateMap();
            SpawnGameObjects();
        }

        private void CreateMap() {
            // 맴 참조
            _map = Map.CreateDefault(20, 20);
        }
        
        private void SpawnGameObjects() {
            MapTile mapTile; // 값 타입임, 지역 변수
            GameObject spawnedObject;
            Coord[] coords = _map.GetShuffledEmptyCoords();
            int coordIndex = 0;

            // 이장님 소환 및 배치
            spawnedObject = new TownNPC_VillageChief("마을 이장", int.MaxValue);
            mapTile = _map.GetTile(coords[coordIndex]);
            mapTile.GameObject = spawnedObject;
            _map.SetTile(mapTile);
            coordIndex++;

            // 슬라임 10마리 생성
            for(int i = 0; i < 10; i++) {
                spawnedObject = new Slime("슬라임", 50);
                mapTile = _map.GetTile(coords[coordIndex]);
                mapTile.GameObject = spawnedObject;
                _map.SetTile(mapTile);
                coordIndex++;
            }

            // 버섯 5마리 생성
            for (int i = 0; i < 5; i++) {
                spawnedObject = new Mushroom("버섯",100, 50);
                mapTile = _map.GetTile(coords[coordIndex]);
                mapTile.GameObject = spawnedObject;
                _map.SetTile(mapTile);
                coordIndex++;
            }

            // 플레이어 케릭터 생성 (전사)
            spawnedObject = new Warrior("순대국밥", 200, 20);
            mapTile = _map.GetTile(coords[coordIndex]);
            mapTile.GameObject = spawnedObject;
            _map.SetTile(mapTile);
            coordIndex++;
        }

        private void GameWorkFlow() {

            while(IsGameOver() == false && IsGameClear() == false) {
                Console.Clear();
                _map.Display();
                HandleInput();
            }
        }

        private bool IsGameOver() {
            // TODO : 플레이어 체력이 0 이하인지 혹은 생성된 적들이 모두 소탕되었는지 확인
            return false;
        }

        private bool IsGameClear() {
            // TODO : 소환된 적이 더 이상 남아있지 않은지
            return false;
        }

        private void HandleInput() {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;

            int targetX = _playerCoord.X;
            int targetY = _playerCoord.Y;

            switch (key) {
                case ConsoleKey.UpArrow:
                    if (_map.IsValid(targetY - 1, targetX) && _map.IsEmpty(targetY - 1, targetX)) {
                        targetY -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (_map.IsValid(targetY + 1, targetX) && _map.IsEmpty(targetY + 1, targetX)) {
                        targetY += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (_map.IsValid(targetY, targetX - 1) && _map.IsEmpty(targetY, targetX - 1)) {
                        targetX -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (_map.IsValid(targetY, targetX + 1) && _map.IsEmpty(targetY, targetX + 1)) {
                        targetX += 1;
                    }
                    break;
                case ConsoleKey.Escape:
                    return;
                default:
                    return;
            }
            _playerCoord = new Coord(targetX, targetY);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    class GamePlayManager
    {
        private Map _map;
        public void PlayGame() {
            InitializedLevel();
            GameWorkFlow();
        }

        private void InitializedLevel() {
            CreateMap();
            SpawnNPCs();
            SpawnPlayer();
        }

        private void CreateMap() {
            // 맴 참조
            _map = Map.CreateDefault(20, 20);
            _map.Display();
        }
        
        private void SpawnNPCs() {
            MapTile mapTile; // 값 타입임, 지역 변수
            GameObject spawnedObject;

            // 촌장님 소환
            if (_map.TryGetEmptyRandomMapTile(out mapTile)) {
                spawnedObject = new TownNPC_VillageChief("마을 이장", int.MaxValue);
                //mapTile.GameObject = spawnedObject; 이렇게 쓰면 값 복사만 일어나고 값 자체는 안 바뀌어서 함수가 끝나면 사라지게 되어 결국에 이장님에 대한 데이터는 안 남게 된다
            }
        }

        private void SpawnPlayer() { }

        private void GameWorkFlow() {
            return;

            while(IsGameOver() == false && IsGameClear() == false                                                                                                                                                                                                                                                                                                                                                                                                          ) {

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
        

    }

}

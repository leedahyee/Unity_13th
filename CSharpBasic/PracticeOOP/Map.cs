namespace PracticeOOP {
    class Map {
        public Map(int width, int height) {
            _tiles = new MapTile[height, width];
        }

        public MapTile[,] tiles => _tiles;
        MapTile[,] _tiles;


        // 맵타일은 값 타입이기 때문에 맵타일을 수정하기 위해서는 맵에 맴타일을 수정하는 코드를 정의
        public bool TrySetGameObject(int x,int y, GameObject gameObject) {
            if (IsEmpty(x, y))
                return false;// 현재 위치가 비어있는지
            
            _tiles[y,x].GameObject = gameObject;
            return true;
        } // 구조체를 참조 형태로 가져와서 수정하는건 안좋음

        // 현재 위치가 비었는지 확인하는 코드
        public bool IsEmpty(int x, int y) {
            return _tiles[y,x].GameObject == null;
        }

        public static Map CreateDefault(int width, int height) {
            Map map = new Map(width, height);

            for (int i = 0; i < map._tiles.GetLength(0); i++) {
                for (int j = 0; j < map._tiles.GetLength(1); j++) {
                    map._tiles[i, j] = new MapTile(coord: new Coord(j, i),
                                                   floorType: FloorType.Grass,
                                                   gameObject: null);
                }
            }

            return map;
        }

        public bool TryGetEmptyRandomMapTile(out MapTile mapTile) {
            Random random = new Random();
            int randomY = random.Next(_tiles.GetLength(0));
            int randomX = random.Next(_tiles.GetLength(1));

            // 타일 비어있음
            if (_tiles[randomY, randomX].GameObject == null) {
                mapTile = _tiles[randomY, randomX];
                return true;
            }

            mapTile = MapTile.Invalid;
            return false;
        }

        public void Display() {
            for (int i = 0; i < _tiles.GetLength(0); i++) {
                for (int j = 0; j < _tiles.GetLength(1); j++) {
                    switch (_tiles[i, j].FloorType) {
                        case FloorType.None:
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case FloorType.Grass:
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;
                        case FloorType.Stone:
                            Console.BackgroundColor = ConsoleColor.Gray;
                            break;
                        case FloorType.Water:
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            break;
                        default:
                            break;
                    }

                    if (_tiles[i, j].GameObject == null) {
                        Console.Write("   ");
                    }
                    else {
                        // TODO : GameObject 의 문자 출력
                    }
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }
    }
}
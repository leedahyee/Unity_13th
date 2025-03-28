using System.Runtime.CompilerServices;
using PracticeOOP.Utilities;

namespace PracticeOOP {
    class Map {
        public Map(int width, int height) {
            _tiles = new MapTile[height, width];
        }

        public MapTile this[int x, int y] {
            get {
                return _tiles[y, x];
            }
            set {
                _tiles[y, x] = value;
            }
        }

        public MapTile this[Coord coord] {
            get {

                return _tiles[coord.Y, coord.X];
            }
            set {
                _tiles[coord.Y,coord.X] = value;
            }
        }


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

        /// <summary>
        /// x, y 좌표가 맴의 경계 내에 존재하는 유효한 좌표인지 확인
        /// </summary>
        /// <returns> true : 유요함, false : 유효하지 않음 </returns>
        public bool IsValid(int x,int y) {
            if(x < 0 || x >= _tiles.GetLength(1))
                return false;
            if (y < 0 || y >= _tiles.GetLength(0))
                return false;
            return true;
        }

        public bool IsValid(Coord coord) {
            if(coord.X < 0 && coord.X >= _tiles.GetLength(1))
                return true;
            if (coord.Y < 0 && coord.Y >= _tiles.GetLength(0))
                return true;
            return true;
        }


        public Coord[] GetShuffledEmptyCoords() {
            Coord[] buffer = new Coord[_tiles.Length];
            int bufferIndex = 0;

            for(int i = 0; i < _tiles.GetLength(0); i++) {
                for(int j = 0; j < _tiles.GetLength(1); j++) {
                    if (IsEmpty(j, i)) {
                        buffer[bufferIndex] = _tiles[j,i].Coord;
                        bufferIndex++;
                    }
                }
            }

            Coord[] emptyCoords = new Coord[bufferIndex];
            Array.Copy(buffer, 0, emptyCoords,0,bufferIndex);

            //for (int i=0; i<emptyCoords.Length;i++) { // emptyCoords.Length = bufferIndex
            //    emptyCoords[i] = buffer[i];
            //} 위의 복사 코드와 동일함

            Random random = new Random();
            random.Shuffle(emptyCoords);
            return emptyCoords;
        }


        public static Map CreateDefault(int width, int height) { // static으로 접근
            Map map = new Map(width, height); // Map 인스턴스 생성

            for (int i = 0; i < map._tiles.GetLength(0); i++) {
                for (int j = 0; j < map._tiles.GetLength(1); j++) {
                    map._tiles[i, j] = new MapTile(coord: new Coord(j, i),
                                                   floorType: FloorType.Grass,
                                                   gameObject: null);
                }
            }
            return map;
        }


        public void SetTile(MapTile mapTile) {
            Coord coord = mapTile.Coord;
            _tiles[coord.Y, coord.X] = mapTile;
        }

        public MapTile GetTile(Coord coord) {
            return _tiles[coord.Y, coord.X];
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
                        Console.Write("  ");
                    }
                    else {
                        // TODO : GameObject 의 문자 출력
                        GameObject gameObject = _tiles[i, j].GameObject;    
                        Console.ForegroundColor = gameObject.SymbolColor;
                        Console.Write($"{gameObject.Symbol}");
                    }
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }
    }
}
/*
 *  이건 그냥 IDisposable 이해용 샘플이니까 내부 구현 디테일은 공부X
 */

using System.Runtime.InteropServices;

namespace CollectionsSample
{
    class AssetLoader : IDisposable
    {
        IntPtr _pAsset;
        bool _disposed;
        const int KB = 1_024;

        public void Load() {
            _pAsset = Marshal.AllocHGlobal(1 * KB); // 임의로 관리되지 않는 힙메모리에 1KB 할당
        }

        // DIspose를 두 개 만든 이유...
        public void Dispose() {
            Dispose(_disposed);
            GC.SuppressFinalize(this); // 이 객체 소멸자 호출하지 말라고 하는 것 (소명자 함수호출 오버헤드를 없애기 위해서)
        }

        private void Dispose(bool dispoising) {
            if(dispoising)
                return;

            if (_pAsset != IntPtr.Zero) {
                Marshal.FreeHGlobal(_pAsset);
                _pAsset = IntPtr.Zero;
            }

            _disposed = true;
        }
    }
}

using OnymojiAuto.Code.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using static OnymojiAuto.Code.Hooks.HookHelper;

namespace OnymojiAuto.Code.UI
{
    class UIEffects
    {
        private Subject<object> mouseActions = new Subject<object>();
        private MouseHookGlobal mouseHook = new MouseHookGlobal();

        public UIEffects()
        {
            mouseHook.MouseAction += mouseActionHandler;
        }

        public Subject<object> MouseActions { get => mouseActions; }

        public void installMouseHoook()
        {
            mouseHook.Install();
        }

        public void stopMouseHook()
        {
            mouseHook.StopHook();
        }

        private void mouseActionHandler(MouseMessages mouseMessage, int x, int y)
        {
            MouseActions.OnNext(new { mouseMessage, x, y });
        }

    }
}

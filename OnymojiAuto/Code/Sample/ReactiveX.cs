using System;
using System.Reactive.Subjects;

namespace OnymojiAuto.Code.Sample
{
    class ReactiveX
    {

        public ReactiveX()
        {
            this.getSubject().Subscribe((data =>
            {
                Console.WriteLine(data);
            }));
        }

        public void test()
        {
            Random rnd = new Random();
            this.getSubject().OnNext(rnd.Next(1,1000));
        }

        Subject<int> sb;
        protected Subject<int> getSubject()
        {
            if (sb == null)
            {
                sb = new Subject<int>();
            }

            return sb;
        }
    }
}

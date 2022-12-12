namespace Задача_1._1
{
    public class MyNode
    {
        public MyNode? next = null;
        public object? value = null;
        public MyNode? parent = null;

        public MyNode(object value)
        {
            this.value = value;
        }

        public MyNode(object value, ref MyNode parent)
        {
            this.value = value;
            this.parent = parent;
        }
    }

    public class MyStack
    {
        public MyNode? head;
        public MyNode? tail;
        int size = 0;

        public MyStack(object head_value)
        {
            this.head = new MyNode(head_value);
            this.tail = head;
            size = 1;
        }

        public MyStack()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        public void PushBack(object value)
        {
            if (this.head == null)
            {
                this.head = new MyNode(value);
                this.tail = this.head;
                ++size;
                return;
            }
            tail.next = new MyNode(value, ref tail)!;
            tail = tail.next;
            size++;
            return;
        }

        public void PopBack()
        {
            if (this.size == 0)
            {
                return;
            }
            if (this.size == 1)
            {
                this.head = null;
                this.tail = null;
                this.size = 0;
                return;
            }
            tail = tail.parent!;
            tail.next = null;
            size--;
            return;
        }

        public object Get()
        {
            if (tail == null)
            {
                return false;
            }
            object value = tail.value;
            this.PopBack();
            return value;
        }

        public object[] ToArray()
        {
            object[] array = new object[size];
            MyNode cur = head!;
            int c = 0;
            if (size == 0)
            {
                return array;
            }
            while (true)
            {
                if (cur == tail)
                {
                    array[c] = cur.value!;
                    return array;
                }
                array[c] = cur.value!;
                cur = cur.next!;
                c++;
            }
        }
    }

    public class MyQueue
    {
        public MyNode? head;
        public MyNode? tail;
        public int size = 0;

        public MyQueue(object head_value)
        {
            head = new MyNode(head_value);
            tail = head;
            size = 1;
        }

        public MyQueue()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        public void PushBack(object value)
        {
            if (this.head == null)
            {
                this.head = new MyNode(value);
                this.tail = head;
                this.size = 1;
                return;
            }
            tail.next = new MyNode(value, ref tail)!;
            tail = tail.next;
            size++;
            return;
        }

        public void PopForward()
        {
            if (this.size == 1)
            {
                this.head = null;
                this.tail = null;
                this.size = 0;
                return;
            }
            if (this.size == 0)
            {
                return;
            }
            head = head.next;
            head.parent = null;
            --size;
        }

        public object Get()
        {
            if (this.head == null)
            {
                return false;
            }
            object value = this.head.value;
            PopForward();
            return value ;
        }

        public object[] ToArray()
        {
            object[] array = new object[size];
            if (head == null)
            {
                return array;
            }
            MyNode cur = head!;
            int c = 0;
            while (true)
            {
                if (cur == tail)
                {
                    array[c] = cur.value!;
                    return array;
                }
                array[c] = cur.value!;
                cur = cur.next!;
                c++;
            }
        }
    }

    public class MyDequeue
    {
        public MyNode? head;
        public MyNode? tail;
        public int size = 0;

        public MyDequeue(object head_value)
        {
            head = new MyNode(head_value);
            tail = head;
            size = 1;
        }

        public MyDequeue()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        public void PushBack(object value)
        {
            if (this.size == 0)
            {
                this.head = new MyNode(value);
                this.tail = head;
                this.size = 1;
                return;
            }
            tail.next = new MyNode(value, ref tail)!;
            tail = tail.next;
            size++;
            return;
        }

        public void PushForward(object value)
        {
            if (this.size == 0)
            {
                this.head = new MyNode(value);
                this.tail = head;
                size++;
                return;
            }
            size++;
            head.parent = new MyNode(value);
            head.parent.next = head;
            head = head.parent;
            return;
        }

        public void PopForward()
        {
            if (this.size == 1)
            {
                this.head = null;
                this.tail = null;
                this.size = 0;
                return;
            }
            if (this.size == 0)
            {
                return;
            }
            head = head.next;
            head.parent = null;
            --size;
        }

        public void PopBack()
        {
            if (this.size == 1)
            {
                this.head = null;
                this.tail = null;
                this.size = 0;
                return;
            }
            if (this.size == 0)
            {
                return;
            }
            tail = tail.parent!;
            tail.next = null;
            size--;
            return;
        }

        public object GetBack()
        {
            if (this.head == null)
            {
                return false;
            }
            object value = tail.value;
            PopBack();

            return value;
        }

        public object GetForward()
        {
            if (head == null)
            {
                return false;
            }
            object value = head.value;
            PopForward();
            return value;
        }

        public object[] ToArray()
        {
            object[] array = new object[size];
            if (this.head == null)
            {
                return array;
            }
            MyNode cur = head!;
            int c = 0;
            while (true)
            {
                if (cur == tail)
                {
                    array[c] = cur.value!;
                    return array;
                }
                array[c] = cur.value!;
                cur = cur.next!;
                c++;
            }
        }
    }

    public class StringStack : Stack<string>
    {
        public string Get()
        {
            if (TryPop(out var r)) return r;
            else return "empty";
        }

        public string Put(string s)
        {
            Push(s);
            return s;
        }
    }

    public class StringQueue : Queue<string>
    {
        public string Get()
        {
            if (this.Count() > 0) return Dequeue();
            else return "empty";
        }

        public string Put(string s)
        {
            Enqueue(s);
            return s;
        }
    }

    public class StringList : List<string>
    {
        public bool Replace(string OldStr, string NewStr)
        {
            for (var i = 0; i < Count; i++)
            {
                if (this[i] == OldStr)
                {
                    this[i] = NewStr;
                    return true;
                }
            }
            return false;
        }

    }
    public class MyLog : StringList
    {
        public string LogFileName = "MyLog.log";
        public string AddTimed(string action, string target, string elem, string currstate, string discr)
        {
            StreamWriter f = File.AppendText(LogFileName);
            DateTime now = DateTime.Now;
            if (currstate.Length > 0) currstate = currstate.Substring(0, currstate.Length - 1);
            string r = now.ToString("yyyy.MM.dd HH:mm:ss") + " -> " + action + " " + elem + " to/from " +
                target + " => {" + currstate + "} :" + discr;
            f.WriteLine(r);
            Insert(0, r);
            f.Close();
            return r;
        }
        public string[] Parse(string s)
        {
            string[] m = s.Split(' ');
            
            if (m.Length > 8)
            {
                m[8] = m[8].Substring(1, m[8].Length - 2);
                string [] r =  { m[3], m[6], m[4], m[8] };
                return r;
            }
            return m;
        }

    }
}


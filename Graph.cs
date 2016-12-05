using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class TSTACK
    {
        private	int []st;
		private int head;
		private int max;

        public TSTACK() {st=null; head=0;}

        public TSTACK(int count)
        {
	        st=new int[count];
	        max=count;
	        head=-1;
        }

        public int Push (int x)
        {
            head++;
            if (head < max)
            {
                st[head] = x;
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Get(ref int x)
        {
	        if (head==-1)
	        {
		        return 0;
	        }
	        x=st[head];
	        return 1;
        }

        public void DeleteTop()
        {
	        if (head>-1)
		        head--;
        }

        public int ToMas (ref int []x)
        {
	        if (head==-1)
		        return 0;
	        else
	        {
		        x=new int[head+1];
		        for (int i = 0; i <= head; i++)
			        x[i]=st[i];
		        return head;
	        }
        }

        public void Create(int count)
        {
	        if (st==null)
	        {
    	        st=new int[count];
		        max=count;
		        head=-1;
	        }
        }

        public void Clear() { head = -1; }

    }

    abstract class TGRAF
    {
        private TSTACK stack;
	    protected int count;
	    public TGRAF()
        {
            count=0;
            stack = new TSTACK();
        }
        public TGRAF(int n)
        {
            stack = new TSTACK(n);
            count = n;
        }

		public abstract int FindAdjVertex(int v, int L);

        public void CreateStack(int count) {stack.Create(count);}
        public int[] FindAllPath(int Path_begin, int Path_end, int a, int b, int Vertex)
        {
            
	        int []Lables=new int [count];
	        int []L=new int[count];
	        int v=0;
	        int vn=Path_begin;
		        
            for (int i = 0; i < count; i++)
		        {
			        Lables[i]=0;
			        L[i]=0;
		        }

		        stack.Clear();
		        stack.Push(vn);
		        Lables[vn]=1;
		        while (stack.Get(ref v)==1)
		        {
			        int vk=FindAdjVertex(v,L[v]);
			        if (vk!=-1)
			        {
				        if (Lables[vk]==0)
				        {
                            
                            stack.Push(vk);
					        Lables[vk]=1;
					        L[vk]=0;
					        L[v]++;
                            if (vk == Path_end)
                            {
                                int[] res = null;
                                stack.ToMas(ref res);
                                bool fl = true;
                                for (int q = 0; q < res.Length && fl; q++)
                                {
                                    fl = !(res[q] == Vertex);
                                }

                                if (fl)
                                    for (int q = 0; q < res.Length; q++)
                                    {
                                        if ((q < res.Length - 1) && (res[q] == a) && (res[q + 1] == b))
                                            return res;
                                    }

                            }
				        }
				        else
				        {
                            if (vk == Path_end)
					        {
                                int[] res = null;
                                stack.ToMas(ref res);
                                bool fl=true;
                                for (int q = 0; q < res.Length && fl; q++)
                                {
                                    fl = !(res[q] == Vertex);
                                }

                                if (fl)
                                    for (int q = 0; q < res.Length; q++)
                                    {
                                        if ((q < res.Length - 1) && (res[q] == a) && (res[q + 1] == b)) 
                                            return res;
                                    }
    
					        }
					        L[v]++;
				        }
			        }
			        else
			        {
				        Lables[v]=0;
				        stack.DeleteTop();
                    }
		        }
            return null;
        }
    }

    class TGraf: TGRAF
    {
        private int []Vertex;
		private int []adjVertex;

        public TGraf(int n, int []x, int []y): base(n)
        {
	        Vertex=new int[n+1];
	        adjVertex=new int[x[n]];
	        for (int i = 0; i <= n; i++)
		        Vertex[i]=x[i];
	        for (int i = 0; i < x[n]; i++)
		        adjVertex[i]=y[i];
        }

        public override int FindAdjVertex(int v, int L)
        {
            if (Vertex[v] + L < Vertex[v + 1])
                return adjVertex[Vertex[v] + L];
            else
                return -1;
        }

        public int StructureOfGraf(ref int []x,ref int []y)
        {
	        x=new int[count+1];
	        y=new int[Vertex[count]];
	        for (int i = 0; i <= count; i++)
		        x[i]=Vertex[i];
	        for (int i = 0; i < Vertex[count]; i++)
		        y[i]=adjVertex[i];
	        return count;
        }
    }
}

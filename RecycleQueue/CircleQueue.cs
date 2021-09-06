using System;
using System.Collections.Generic;
using System.Text;

namespace CircleQueue
{
    /// <summary>
    /// 참고자료 : 뇌를 자극하는 알고리즘
    /// C -> C#
    /// 
    /// 환형큐의 배경:
    /// 선형 자료구조 Queue를 배열로 나타내려고 했더니
    /// 아니 글쎄 Dequeue를 해줄 때 마다 배열을 한칸씩 앞당기네!?
    /// 너무 비효율적이야... ㅠㅠ
    /// 
    /// 오 그렇다면 시작과 끝의 경계를 없애는게 어때!?
    ///  
    /// 만약 시작과 끝이 같다면 해당 배열은 비어있는거지!
    /// 음 그럼 꽉찬건??
    /// 그것도 같을텐데..?
    /// 으윽.. 그러면 한칸을 더 할당 받고 이건 공백 판별용으로 놔두자!
    /// 굳굳
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CircleQueue<T> where T : new ()
    {
        int m_capacity;
        int m_front;
        int m_rear;
        T[] m_arr;
       
        public bool isEmpty
        {
            get 
            {
                return m_front == m_rear;
            }
        }
        public bool isFull
        {
            get
            {
                return ((m_rear + 1) % m_capacity) == m_front;
                //return (m_rear+1 == m_front) || (m_rear - m_front == m_capacity);
            }
        }
        /// <summary>
        /// 실제 배열의 크기는 공백으로 인해 하나 더 많다
        /// 공백의 이유는 
        /// 꽉찼는지 확인하기 위함.
        /// 공백은 계속 놔둘거임.
        /// </summary>
        /// <param name="m_capacity"></param>
        public CircleQueue(int m_capacity)
        {
            this.m_capacity = m_capacity;
            m_arr = new T[this.m_capacity + 1];
            m_front = 0;
            m_rear = 0;
           
        }
        /// <summary>
        /// Capacity 변경
        /// </summary>
        /// <param name="n_capacity">새로운 용량</param>
        public void Capacity(int n_capacity)
        {
            m_capacity = n_capacity;
            Array.Resize<T>(ref m_arr, m_capacity + 1);
        }

        /// <summary>
        /// 이해를 돕기 위한 그림
        /// * = 공백
        /// O = 사용중
        /// X = 비어있음
        /// -----------------------------
        /// Case 1
        /// Enqueue * 5
        ///  0  1  2  3  4  5
        /// [O][O][O][O][O][*]
        ///  F           R
        /// 한번더 Enqueue
        /// => 4+1 % 5 == 0 : true -> isFull
        /// -----------------------------
        /// Case 2
        /// Enqueue * 5
        /// Dequeue
        ///  0  1  2  3  4  5
        /// [X][O][O][O][O][*]
        ///     F        R
        /// 한번더 Enqueue
        /// => 4+1 % 5 == 1 : false -> Enqueue 가능
        /// -----------------------------
        /// </summary>
        /// <returns></returns>
        public bool Enqueue(T input)
        {
            if (isFull)
            {
                Console.WriteLine("IsFull");
                return false;
            }
            int position = m_rear % m_capacity;
            m_arr[position] = input;
            m_rear = position;
            m_rear++;
            return true;
        }
       
        public T Dequeue()
        {
            if (isEmpty)
            {
                return new T();
            }
            int position = m_front % m_capacity;
            m_front = position;
            m_front++;
            T result = m_arr[position];
            m_arr[position] = new T();
            return result;
        }
        public void Print()
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            foreach (T m in m_arr)
            {
                sb.AppendLine($"{count} :"+m.ToString());
                count++;
            }
            Console.WriteLine(sb.ToString());
        }
    }
}

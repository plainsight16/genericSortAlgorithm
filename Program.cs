namespace genericSort
{
    public class Program
    {
        public static void Main(String[] args)
        {
            
            // var unsortedList = new List<int>{ 5, 4, 3, 2, 1 };
            // Console.Write("Unsorted List: ");
            // printList(unsortedList);

            // var sortedList = Sort(unsortedList);
            // Console.Write("Sorted List: ");
            // printList(sortedList);
            int[] arr = { 5, 4, 3, 2, 1 };
            SelectionSort(arr);
            printList(arr.ToList());

        }       
        /// <summary>
        /// A function that prints out to the console a list of any type in specified format.
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>

        private static void  printList<T> (List<T> list)
        {   
            int i = 0;
            Console.Write("{");
            foreach (var item in list)
            {
                if(i == list.Count - 1)
                {
                    Console.Write(item);
                }
                else
                {
                    Console.Write(item + ", ");
                }
                i++;
            }
            Console.Write("}");
            Console.WriteLine();
        }
        /// <summary>
        /// A generic sort function that takes in a list of any type and sorts it.
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>list<T></returns>
        public static List<T> Sort<T>(List<T> list) where T : IComparable<T>
        {
            T[] arr = list.ToArray();
            int length = arr.Length;

            if (length == 0) throw new ArgumentException("List is empty"); 
        
            if (length < 16)
            {
                var sortedArray = insertionSort(arr, length);
                return sortedArray.ToList();
            }
            else if (length > (2 * Math.Log(length)))
            {
                var sortedArray = heapSort(arr, length);
                return sortedArray.ToList();
            }
            else
            {
                var sortedArray = quickSort(arr, 0, length - 1);
                return sortedArray.ToList();
            }
        }

        /// <summary>
        /// A helper fuction to the Sort function that sorts an array of any type using the insertion sort algorithm.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static T[] insertionSort<T>(T[] arr, int n) where T : IComparable<T>
        {
            for (int i = 1; i < n; ++i)
            {
                var key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j].CompareTo(key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
            return arr;
        }

        /// <summary>
        /// A helper fuction to the Sort function that sorts an array of any type using the quick sort algorithm.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static T[] quickSort<T>(T[] arr, int low, int high) where T : IComparable<T>
        {
            if (low < high)
            {
                int pi = partition(arr, low, high);

                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
            return arr;
        }

        /// <summary>
        /// A helper fuction to the quickSort function that partitions an array of any type.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static int partition<T>(T[] arr, int low, int high) where T : IComparable<T>
        {
            var pivot = arr[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (arr[j].CompareTo(pivot) < 0)
                {
                    i++;

                    var temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            var temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }

        /// <summary>
        /// A helper function to the Sort function that sorts an array of any type using the heap sort algorithm.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static T[] heapSort<T>(T[] arr, int n) where T : IComparable<T>
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
                var temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                heapify(arr, i, 0);
            }
            return arr;
        }

        /// <summary>
        /// A helper function to the heapSort function that heapifies an array of any type.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <param name="i"></param>
        /// <typeparam name="T"></typeparam>
        private static void heapify<T>(T[] arr, int n, int i) where T : IComparable<T>
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && (arr[l].CompareTo(arr[largest]) > 0))
                largest = l;

            if (r < n && (arr[r].CompareTo(arr[largest]) > 0))
                largest = r;

            if (largest != i)
            {
                var swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                heapify(arr, n, largest);
            }
        }

        // private static List<int> MergeSort(int l, int h)
        // {
        //     while (l != h)
        //     {
        //         if (l < h)
        //         {
        //             int mid = (l + h) / 2;

        //             MergeSort(l, mid);
        //             MergeSort(mid + 1, h);
        //             Merge(l, mid, h);
        //         }
        //     }
        // }

        // private static void Merge(int l, int mid, int h)
        // {
        //     while (l <= mid && mid + 1 < h)
        //     {
        //         if (array[l] < array[mid + 1])
        //             newArray[k++] = array[l++];
        //         else
        //             newArray[k++] = array[(mid + 1)++];
        //     }
        //     for (; l <= mid; l++)
        //     {
        //         newArray[k++] = array[l++];
        //     }
        //     for (; mid + 1 <= h; mid++)
        //     {
        //         newArray[k++] = array[l++];
        //     }
        // }
        private static void Init(int[] arr)
        {
            // for(int i = 1; i < arr.Length; i++)
            // {
            //     int key = i;
            //     for (int j = key - 1; j >= 0; j--)
            //     {
            //         if (arr[key] < arr[j])
            //         {
            //             int temp = arr[key];
            //             arr[key] = arr[j];
            //             arr[j] = temp;
            //             key--;
            //         }
            //     }
            // }

            for (int i = 1; i < arr.Length; i++)
            {
                int key =  arr[i];

                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        private static void BubbleSort(int[] arr)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                for (int i = 0; i < arr.Length - (j + 1); i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }    
            }
        }

        private static void SelectionSort(int[] arr)
        {   
            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    int temp = arr[min];
                    arr[min] = arr[i];
                    arr[i] = temp;
                }
            }
        }
    }
}
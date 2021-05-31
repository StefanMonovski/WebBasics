using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ParallelMergeSort
{
    class AsynchronousMergeSort
    {
        private void Merge(List<int> numbers, int left, int middle, int right)
        {
            int leftSize = middle - left + 1;
            int rightSize = right - middle;

            List<int> leftNumbers = new();
            List<int> rightNumbers = new();
            int i, j;

            Parallel.Invoke(() => GetLeftNumbers(numbers, leftNumbers, leftSize, left), 
                () => GetRightNumbers(numbers, rightNumbers, rightSize, middle));

            i = 0;
            j = 0;

            int k = left;
            while (i < leftSize && j < rightSize)
            {
                if (leftNumbers[i] <= rightNumbers[j])
                {
                    numbers[k] = leftNumbers[i];
                    i++;
                }
                else
                {
                    numbers[k] = rightNumbers[j];
                    j++;
                }
                k++;
            }

            while (i < leftSize)
            {
                numbers[k] = leftNumbers[i];
                i++;
                k++;
            }

            while (j < rightSize)
            {
                numbers[k] = rightNumbers[j];
                j++;
                k++;
            }
        }

        private static void GetLeftNumbers(List<int> numbers, List<int> leftNumbers, int leftSize, int left)
        {
            for (int i = 0; i < leftSize; ++i)
            {
                leftNumbers.Add(numbers[left + i]);
            }
        }


        private static void GetRightNumbers(List<int> numbers, List<int> rightNumbers, int rightSize, int middle)
        {
            for (int j = 0; j < rightSize; ++j)
            {
                rightNumbers.Add(numbers[middle + 1 + j]);
            }
        }

        public void Sort(List<int> numbers, int left, int right)
        {
            if (right > left)
            {
                int middle = left + (right - left) / 2;

                Parallel.Invoke(() => Sort(numbers, left, middle), () => Sort(numbers, middle + 1, right));

                Merge(numbers, left, middle, right);
            }
        }

        public string SortAndPrint(List<int> numbers)
        {
            Sort(numbers, 0, numbers.Count - 1);
            return string.Join(" ", numbers);
        }
    }
}

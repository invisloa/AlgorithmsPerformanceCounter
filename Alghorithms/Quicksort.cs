﻿using AlgoTestProjHomeWork.Writers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTestProjHomeWork.Alghorithms
{
	public class Quicksort : IAlgoTally
	{
		long actionsTaken = 0;
		public long ActionsCounted => actionsTaken;
		Stopwatch stopwatch = new Stopwatch();
		public Stopwatch Stopwatch { get => stopwatch; }
		public int[] SortArray(int[] array)
		{
			int[] copyArrayToSort = new int[array.Length];
			Array.Copy(array, copyArrayToSort, array.Length);

			QSort(copyArrayToSort, 0, copyArrayToSort.Length - 1);
			return copyArrayToSort;
		}

		public void QSort(int[] array, int left, int right)
		{
			stopwatch.Start();
			actionsTaken++;

			if (left < right)
			{
				int pivotIndex = Partition(array, left, right);
				QSort(array, left, pivotIndex - 1);
				QSort(array, pivotIndex + 1, right);
			}
			stopwatch.Stop();
		}
		int Partition(int[] array, int left, int right)
		{

			int pivot = array[right];
			int i = left - 1;
			for (int j = left; j < right; j++)
			{
				if (array[j] <= pivot)
				{
					i++;
					Swap(array, i, j);
				}
			}
			Swap(array, i + 1, right);
			return i + 1;
		}
		void Swap(int[] array, int i, int j)
		{
			int temp = array[i];
			array[i] = array[j];
			array[j] = temp;
		}

	}
}

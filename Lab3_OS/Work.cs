using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OS
{
  class Work
  {
    public static void Find()
    {
      string start;
      start = File.ReadAllText("./test.txt");
      string[] start4 = new string[4];
      string[] start5 = new string[5];
      string[] treatment = new string[16];
      var tmp = start.Split(' ');
      int k = 4;

      for (int j = 0; j < k; j++)
      {
        start4[j] = tmp[j];
        start5[j] = tmp[j];
      }
      start5[4] = " ";
      for (int i = 0; i < 16; i++)
      {
        treatment[i] = tmp[i + 4];
      }
      Fifo(start4, treatment, 4);
      Lru(start4, treatment, 4);
      Fifo(start5, treatment, 5);
      Lru(start5, treatment, 5);
    }


    public static void Fifo(string[] start, string[] treat, int k)
    {
      int inter = 0;
      for (int i = 0; i < 16; i++)
      {
        if (k == 4)
        {
          if (treat[i] == start[0] || treat[i] == start[1] || treat[i] == start[2] || treat[i] == start[3])
            continue;
          else
          {
            inter++;
            start[0] = start[1];
            start[1] = start[2];
            start[2] = start[3];
            start[3] = treat[i];
          }
        }
        else if (k == 5)
        {
          if (treat[i] == start[0] || treat[i] == start[1] || treat[i] == start[2] || treat[i] == start[3] || treat[i] == start[4])
            continue;
          else
          {
            if (start[4] == " ")
            {
              start[4] = treat[i];
              inter++;
            }
            else
            {
              inter++;
              start[0] = start[1];
              start[1] = start[2];
              start[2] = start[3];
              start[3] = start[4];
              start[4] = treat[i];
            }
          }
        }
      }
      if (k == 4)
        Console.WriteLine("Прерываний для FIFO в случае четырех блоков: " + inter);
      else
        Console.WriteLine("Прерываний для FIFO в случае пяти блоков: " + inter);
    }


    public static void Lru(string[] start, string[] treat, int k)
    {
      int inter = 0;
      string tmp;
      for (int i = 0; i < 16; i++)
      {
        if (k == 4)
        {
          if (treat[i] == start[0])
          {
            tmp = start[0];
            start[0] = start[1];
            start[1] = start[2];
            start[2] = start[3];
            start[3] = tmp;
            continue;
          }
          else if (treat[i] == start[1])
          {
            tmp = start[1];
            start[1] = start[2];
            start[2] = start[3];
            start[3] = tmp;
            continue;
          }
          else if (treat[i] == start[2])
          {
            tmp = start[2];
            start[2] = start[3];
            start[3] = tmp;
            continue;
          }
          else if (treat[i] == start[3])
          {
            continue;
          }
          else
          {
            inter++;
            start[0] = start[1];
            start[1] = start[2];
            start[2] = start[3];
            start[3] = treat[i];
          }
        }
        else if (k == 5)
        {
          if (treat[i] == start[0])
          {
            tmp = start[0];
            start[0] = start[1];
            start[1] = start[2];
            start[2] = start[3];
            start[3] = start[4];
            start[4] = tmp;
            continue;
          }
          else if (treat[i] == start[1])
          {
            tmp = start[1];
            start[1] = start[2];
            start[2] = start[3];
            start[3] = start[4];
            start[4] = tmp;
            continue;
          }
          else if (treat[i] == start[2])
          {
            tmp = start[2];
            start[2] = start[3];
            start[3] = start[4];
            start[4] = tmp;
            continue;
          }
          else if (treat[i] == start[3])
          {
            tmp = start[3];
            start[3] = start[4];
            start[4] = tmp;
            continue;
          }
          else if (treat[i] == start[4])
          {
            continue;
          }
          else
          {
            if (start[4] == " ")
            {
              start[4] = treat[i];
              inter++;
            }
            else
            {
              inter++;
              start[0] = start[1];
              start[1] = start[2];
              start[2] = start[3];
              start[3] = start[4];
              start[4] = treat[i];
            }
          }
        }
        
      }
      if (k == 4)
        Console.WriteLine("Прерываний для LRU в случае четырех блоков: " + inter);
      else
        Console.WriteLine("Прерываний для LRU в случае пяти блоков: " + inter);
    }
  }
}



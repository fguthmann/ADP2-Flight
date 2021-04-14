using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public interface IData
{
    int getChunkSize();
    int getMaxIndex();
    string getChunk(int num);
    float getElement(string attr, int frame);
    List<string> getAttrNames();
}


class CSData : IData
{
    private List<string> attsNames;
    private Dictionary<int, string> frames;
    private Dictionary<string, List<float>> attributes;
    private int lineSize;
    public CSData(List<string> names, String csvLocation)
    {
        attsNames = names;
        frames = new();
        attributes = new();
        using (StreamReader sr = new StreamReader(csvLocation))
        {
            string currentLine;
            int i = 0;
            string att;
            string[] tmp = names.ToArray();
            foreach (string s in names)
            {
                att = s;
                List<float> v = new();
                attributes[att] = v;
                //attsNames.Add(att);
                i++;
            }

            // currentLine will be null when the StreamReader reaches the end of file
            int j = 0;
            while ((currentLine = sr.ReadLine()) != null)
            {
                frames.Add(j, currentLine);
                string[] words = currentLine.Split(',');
                i = 0;
                foreach (var word in words)
                {
                    attributes[attsNames[i]].Add(float.Parse(word));
                    i++;
                }
                j++;
            }
            lineSize = i;
        }

    }

    public List<string> getAttrNames()
    {
        List<string> tmp = new();
        tmp.AddRange(attsNames);
        return tmp;
    }

    public string getChunk(int num)
    {
        string s = frames[num] + "\n";
        return s;
    }

    public int getChunkSize()
    {
        return lineSize;
    }

    public float getElement(string attr, int frame)
    {
        if(attr != " ")
        {
            return (attributes[attr])[frame];
        }
        return 0;
    }

    public int getMaxIndex()
    {
        return frames.Count - 1;
    }
}

/**
 
public class TSDataAdapter : IData
{
    //note that size_t is not compatible with the DLL transition, and therefore the return value is int.
    [DllImport("DllForAnomalyDetector")]
    public static extern int GetRowSize(IntPtr ts);


    //the return value is stringWrapper! get it as IntPtr and cast it to string (example below)
    [DllImport("DllForAnomalyDetector", CallingConvention = CallingConvention.Cdecl)]
    //[return: MarshalAs(UnmanagedType.LPStr)]
    public static extern IntPtr GetFrame(IntPtr ts, int frame);

    [DllImport("DllForAnomalyDetector")]
    public static extern char GetCharByIndex(IntPtr str, int x);

    [DllImport("DllForAnomalyDetector")]
    public static extern int GetMaxFrame(IntPtr ts);

    [DllImport("DllForAnomalyDetector.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetAttr(IntPtr ts, char[] attr, int frame);


    //the return value is string! get it as IntPtr and cast it to string (example below)
    [DllImport("DllForAnomalyDetector", CallingConvention = CallingConvention.Cdecl)]
    //[return: MarshalAs(UnmanagedType.LPStr)]
    public static extern int GetFrameLength(IntPtr ts, int frame);



    private IntPtr timeseries;

    public TSDataAdapter(IntPtr ts)
    {
        timeseries = ts;
    }

    int IData.getChunkSize()
    {
        return GetRowSize(timeseries);
    }
    int IData.getMaxIndex()
    {
        return GetMaxFrame(timeseries);
    }
    string IData.getChunk(int num)
    {
        IntPtr dllstr = GetFrame(timeseries, num);
        //cast it to string using Marshal
        int i;
        char c;
        string frame = "";
        int str_len = GetFrameLength(timeseries, num);
        for (i = 0; i < str_len; i++)
        {
            c = GetCharByIndex(dllstr, i);
            frame += c.ToString();
        }
        frame += "\n";
        return frame;
    }
    float IData.getElement(string attr, int frame)
    {
        try
        {
            return GetAttr(timeseries, attr.ToCharArray(), frame);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        return 0;
    }

}
*/
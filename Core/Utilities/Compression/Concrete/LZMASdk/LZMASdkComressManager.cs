using Core.Utilities.Compression.Abstract;
using SevenZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Compression.Concrete.LZMASdk
{

    public class LZMASdkComressManager : ICompressService
    {
        public void Compress(string FolderToCompress, string destination)
        {
            List<string> subfiles = new List<string>(Directory.GetFiles(FolderToCompress));
            FileInfo fi = new FileInfo(FolderToCompress);
            StringBuilder output_7zip_File = new StringBuilder(FolderToCompress + Path.DirectorySeparatorChar + fi.Name + @".lzma");
            string output_stringBuilder = output_7zip_File.ToString();

            Console.WriteLine("Output destination : " + output_stringBuilder);


            foreach (string file in subfiles)
            {
                CompressFileLZMA(file, file + ".lzma");
            }

        }

        public void CompressFileLZMA(string inFile, string outFile)
        {
            Int32 dictionary = 1 << 23;
            Int32 posStateBits = 2;
            Int32 litContextBits = 3; // for normal files
            // UInt32 litContextBits = 0; // for 32-bit data
            Int32 litPosBits = 0;
            // UInt32 litPosBits = 2; // for 32-bit data
            Int32 algorithm = 2;
            Int32 numFastBytes = 128;

            string mf = "bt4";
            bool eos = true;
            bool stdInMode = false;


            CoderPropID[] propIDs =  {
                CoderPropID.DictionarySize,
                CoderPropID.PosStateBits,
                CoderPropID.LitContextBits,
                CoderPropID.LitPosBits,
                CoderPropID.Algorithm,
                CoderPropID.NumFastBytes,
                CoderPropID.MatchFinder,
                CoderPropID.EndMarker
            };

            object[] properties = {
                (Int32)(dictionary),
                (Int32)(posStateBits),
                (Int32)(litContextBits),
                (Int32)(litPosBits),
                (Int32)(algorithm),
                (Int32)(numFastBytes),
                mf,
                eos
            };


            try
            {
                using (FileStream inStream = new FileStream(inFile, FileMode.Open))
                {

                    using (FileStream outStream = new FileStream(outFile, FileMode.Create))
                    {
                        SevenZip.Compression.LZMA.Encoder encoder = new SevenZip.Compression.LZMA.Encoder();
                        encoder.SetCoderProperties(propIDs, properties);
                        encoder.WriteCoderProperties(outStream);
                        Int64 fileSize;
                        if (eos || stdInMode)
                            fileSize = -1;
                        else
                            fileSize = inStream.Length;
                        for (int i = 0; i < 8; i++)
                        {
                            outStream.WriteByte((Byte)(fileSize >> (8 * i)));


                        }
                        encoder.Code(inStream, outStream, -1, -1, null);
                    }
                }
                File.Delete(inFile);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR : " + e.Message);
            }


        }
    }
}

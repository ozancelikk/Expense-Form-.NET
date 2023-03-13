using System;
using System.Collections.Generic;
using System.IO;

namespace Core.Utilities.HardwareInfo.Components
{
   
    /// <summary>
    /// WMI class: Win32_LogicalDisk
    /// </summary>
    public class Volume
    {
        /// <summary>
        /// Short description of the object (a one-line string).
        /// </summary>
        public string Caption { get; set; } = string.Empty;

        /// <summary>
        /// If True, the logical volume exists as a single compressed entity, such as a DoubleSpace volume. 
        /// If file based compression is supported, such as on NTFS, this property is False.
        /// </summary>
        public Boolean Compressed { get; set; }

        /// <summary>
        /// Description of the object.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// File system on the logical disk.
        /// </summary>
        public string FileSystem { get; set; } = string.Empty;

        /// <summary>
        /// Space, in bytes, available on the logical disk.
        /// </summary>
        public UInt64 FreeSpace { get; set; }

        /// <summary>
        /// Label by which the object is known.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Size of the disk drive.
        /// </summary>
        public UInt64 Size { get; set; }

        /// <summary>
        /// Volume name of the logical disk.
        /// </summary>
        public string VolumeName { get; set; } = string.Empty;

        /// <summary>
        /// Volume serial number of the logical disk.
        /// </summary>
        public string VolumeSerialNumber { get; set; } = string.Empty;

        public override string ToString()
        {
            return
                "Caption: " + Caption + Environment.NewLine +
                "Compressed: " + Compressed + Environment.NewLine +
                "Description: " + Description + Environment.NewLine +
                "FileSystem: " + FileSystem + Environment.NewLine +
                "FreeSpace: " + FreeSpace + Environment.NewLine +
                "Name: " + Name + Environment.NewLine +
                "Size: " + Size + Environment.NewLine +
                "VolumeName: " + VolumeName + Environment.NewLine +
                "VolumeSerialNumber: " + VolumeSerialNumber + Environment.NewLine;
        }
    }

    // https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-diskpartition

    /// <summary>
    /// WMI class: Win32_DiskPartition
    /// </summary>
    public class Partition
    {
        public List<Volume> VolumeList { get; set; } = new List<Volume>();

        /// <summary>
        /// Indicates whether the computer can be booted from this partition.
        /// </summary>
        public Boolean Bootable { get; set; }

        /// <summary>
        /// Partition is the active partition. 
        /// The operating system uses the active partition when booting from a hard disk.
        /// </summary>
        public Boolean BootPartition { get; set; }

        /// <summary>
        /// Short description of the object.
        /// </summary>
        public string Caption { get; set; } = string.Empty;

        /// <summary>
        /// Description of the object.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Index number of the disk containing this partition.
        /// </summary>
        public UInt32 DiskIndex { get; set; }

        /// <summary>
        /// Index number of the partition.
        /// </summary>
        public UInt32 Index { get; set; }

        /// <summary>
        /// Label by which the object is known.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// If True, this is the primary partition.
        /// </summary>
        public Boolean PrimaryPartition { get; set; }

        /// <summary>
        /// Total size of the partition.
        /// </summary>
        public UInt64 Size { get; set; }

        /// <summary>
        /// Starting offset (in bytes) of the partition.
        /// </summary>
        public UInt64 StartingOffset { get; set; }

        public override string ToString()
        {
            return
                "Bootable: " + Bootable + Environment.NewLine +
                "BootPartition: " + BootPartition + Environment.NewLine +
                "Caption: " + Caption + Environment.NewLine +
                "Description: " + Description + Environment.NewLine +
                "DiskIndex: " + DiskIndex + Environment.NewLine +
                "Index: " + Index + Environment.NewLine +
                "Name: " + Name + Environment.NewLine +
                "PrimaryPartition: " + PrimaryPartition + Environment.NewLine +
                "Size: " + Size + Environment.NewLine +
                "StartingOffset: " + StartingOffset + Environment.NewLine;
        }
    }

    // https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-diskdrive

    /// <summary>
    /// WMI class: Win32_DiskDrive
    /// </summary>
    public class Drive
    {

        /// <summary>
        /// Label by which the object is known.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        public long AvailableFreeSpace { get; set; }
       
        public string DriveFormat { get; set; }
     
        public DriveType DriveType { get; set; }
      
        public bool IsReady { get; set; }
       
        public long TotalFreeSpace { get; set; }
      
        public long TotalSize { get; set; }
     
        public string VolumeLabel { get; set; }



        public override string ToString()
        {
            return
                "AvailableFreeSpace: " + AvailableFreeSpace + Environment.NewLine +
                "DriveFormat: " + DriveFormat + Environment.NewLine +
                "DriveType: " + DriveType + Environment.NewLine +
                "IsReady: " + IsReady + Environment.NewLine +
                "TotalFreeSpace: " + TotalFreeSpace + Environment.NewLine +
                "TotalSize: " + TotalSize + Environment.NewLine +
                "VolumeLabel: " + VolumeLabel + Environment.NewLine +
                "Name: " + Name + Environment.NewLine;
        }
    }
}

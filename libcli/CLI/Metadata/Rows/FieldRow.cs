/* This file is automatically generated by cliutil.exe */
using System;
using CooS.Formats.CLI.Metadata.Heaps;
using CooS.Formats.CLI.Metadata.Indexes;

namespace CooS.Formats.CLI.Metadata.Rows {

	public struct FieldRow : IRow {

		public const TableId TableId = CooS.Formats.CLI.Metadata.TableId.Field;

		public int Index;
		public FieldAttributes Flags;
		public StringHeapIndex Name;
		public BlobHeapIndex Signature;

		public int RowIndex {
			get {
				return this.Index;
			}
			set {
				this.Index = value;
			}
		}

	}

	public struct FieldRowIndex : IRowIndex {

		public readonly int Value;

		int IRowIndex.RawIndex {
			get {
				return this.Value;
			}
		}

		internal FieldRowIndex(int value) {
			this.Value = value;
		}

		public static explicit operator FieldRowIndex(RowIndex rowIndex) {
			return new FieldRowIndex(rowIndex.Value);
		}

		public static implicit operator RowIndex(FieldRowIndex rowIndex) {
			return new RowIndex(rowIndex.Value);
		}

	}

	internal class FieldRowFactory : RowFactory<FieldRow> {

		public FieldRowFactory(TablesHeap heap) : base(heap) {
		}

		public override TableId TableId { get { return FieldRow.TableId; } }

		public override int GetPhysicalSize() {
			return 0
				+ 2
				+ Heap.GetPhysicalSizeOfIndex(HeapIndexes.String)
				+ Heap.GetPhysicalSizeOfIndex(HeapIndexes.Blob)
				;
		}

		public override FieldRow Parse(byte[] buf, ref int position) {
			FieldRow value;
			value.Index = 0;
			value.Flags = (FieldAttributes)Heap.ReadEnum16(buf, ref position);
			value.Name = Heap.ReadStringHeapIndex(buf, ref position);
			value.Signature = Heap.ReadBlobHeapIndex(buf, ref position);
			return value;
		}

	}

}

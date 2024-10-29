using System;
using System.Collections.Generic;
using Android.Database;
using Android.Runtime;

namespace keepass2android
{
    public class FilteredCursor : CursorWrapper
    {
        private readonly Predicate<ICursor> _filter;
        private List<int> _indicesToKeep;
        private int _pos;

        public override bool Requery()
        {
            bool result = base.Requery();
            UpdateFilterIndices();
            return result;
        }

        protected FilteredCursor(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
        
        public FilteredCursor(ICursor cursor, Predicate<ICursor> filter) : base(cursor)
        {
            _filter = filter;
            UpdateFilterIndices();
        }

        private void UpdateFilterIndices()
        {
            _indicesToKeep = new List<int>();
            int index = 0;
            for (base.WrappedCursor.MoveToFirst(); !base.WrappedCursor.IsAfterLast; base.WrappedCursor.MoveToNext())
            {
                if (_filter(base.WrappedCursor))
                    _indicesToKeep.Add(index);
                index++;
            }
            _pos = -1;
        }

        public override int Count
        {
            get
            {
                return _indicesToKeep.Count;
            }
        }

        public override bool MoveToPosition(int position)
        {
            if (position >= Count)
            {
                _pos = Count;
                return false;
            }
            if (position < 0)
            {
                _pos = -1;
                return false;
            }
            return base.MoveToPosition(_indicesToKeep[position]);
        }

        public override bool Move(int offset)
        {
            return MoveToPosition(_pos+offset);
        }

        public override bool MoveToFirst()
        {
            return MoveToPosition(0);
        }

        public override bool MoveToNext()
        {
            return MoveToPosition(_pos+1);
        }

        public override bool MoveToLast()
        {
            return MoveToPosition(Count-1);
        }

        public override bool MoveToPrevious()
        {
            return MoveToPosition(_pos-1);
        }

        public override bool IsAfterLast
        {
            get { return _pos >= Count; }
        }

        public override bool IsBeforeFirst
        {
            get { return _pos < 0; }
        }

        public override bool IsFirst
        {
            get { return _pos == 0; }
        }

        public override bool IsLast
        {
            get { return _pos == Count-1; }
        }

        public override int Position
        {
            get { return _pos; }
        }

    }
}
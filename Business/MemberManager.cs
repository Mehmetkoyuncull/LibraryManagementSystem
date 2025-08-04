using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using DataAccess;

namespace Business
{
    public class MemberManager
    {
        private readonly string _filePath = "members.json";
        private List<Member> _members;

        public MemberManager()
        {
            _members = FileHelper<Member>.LoadFromFile(_filePath);
        }

        public List<Member> GetAll()
        {
            return _members;
        }

        public Member GetById(int id)
        {
            return _members.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Member member)
        {
            // TC No kontrolü
            if (member.TCNo.Length != 11 || !member.TCNo.All(char.IsDigit))
                throw new Exception("TC Kimlik Numarası 11 haneli olmalıdır.");

            if (_members.Any(m => m.TCNo == member.TCNo))
                throw new Exception("Bu TC Kimlik Numarası zaten kayıtlı.");

            // Otomatik artan Id
            member.Id = GetNextId();

            _members.Add(member);
            Save();
        }

        public void Remove(int id)
        {
            var member = _members.FirstOrDefault(m => m.Id == id);
            if (member != null)
            {
                _members.Remove(member);
                Save();
            }
        }

        public void Update(Member updatedMember)
        {
            var index = _members.FindIndex(m => m.Id == updatedMember.Id);
            if (index != -1)
            {
                _members[index] = updatedMember;
                Save();
            }
        }

        public int GetNextId()
        {
            if (_members.Count == 0)
                return 1;
            return _members.Max(m => m.Id) + 1;
        }

        private void Save()
        {
            FileHelper<Member>.SaveToFile(_members, _filePath);
        }
    }
}

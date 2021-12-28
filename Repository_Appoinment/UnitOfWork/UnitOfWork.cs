using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Threading.Tasks;
using Repository_Appoinment.Dtos;

namespace Repository_Appoinment.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private AppoinmentDBContext _context = null;
        private GenericRepository<PatientAppoinment> __patientAppoinment;

        #endregion

        public UnitOfWork()
        {
            _context = new AppoinmentDBContext();
        }

        #region Public Repository Creation properties...

        public GenericRepository<PatientAppoinment> PatientAppointmentRepository
        {
            get
            {
                if (__patientAppoinment == null)
                {
                    __patientAppoinment = new GenericRepository<PatientAppoinment>(_context);
                }
                return __patientAppoinment;
            }
        }


        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public async Task<int> Save()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                //System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);
                Debug.WriteLine("Errors : " + outputLines);
                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
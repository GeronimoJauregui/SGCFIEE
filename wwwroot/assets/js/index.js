$(document).ready(function(){
   $("#academicos_datosgenerales").on('click',function(){
      Academicos_datosgenerales.cargarModulo(); 
   }),
   $("#academicos_EE").on('click',function(){       
      Academicos_EE.cargarModulo(); 
   }),
   $("#academicos_pafis").on('click',function(){       
      Academicos_Pafis.cargarModulo(); 
   }),
   $("#academicos_tutoria").on('click',function(){       
      Academicos_Tutoria.cargarModulo(); 
   }),
   $("#academicos_evaluaciones").on('click',function(){       
      Academicos_Evaluaciones.cargarModulo(); 
   }),
   $("#academicos_produccion").on('click',function(){       
      Academicos_Produccion.cargarModulo(); 
   }),
   $("#academicos_instructorEC").on('click',function(){       
      Academicos_InstructorEC.cargarModulo(); 
   }),
   $("#academicos_coordinadores").on('click',function(){       
      Academicos_Coordinadores.cargarModulo(); 
   }),
   $("#academicos_CT").on('click',function(){       
      Academicos_CT.cargarModulo(); 
   });
   $("#infogeneral").on('click',function(){
       EstudianteDatosGenerales.cargaForm();
   }),
   $("#buzon").on('click',function(){
       EstudianteBuzon.cargaBuzon();
   }),
   $("#pafisalum").on('click',function(){
       EstudiantePafi.cargaPafi();
   }),
   $("#movilidad").on('click',function(){
       EstudianteMovilidad.cargaMovi();
   });
   $("#eventosalum").on('click',function(){
       EstudianteEventos.cargaEventos();
   });
   $("#pafis").on('click',function(){       
      Pafis.cargarModulo(); 
   });
   $("#estudiantescom").on('click',function(){
      EstudianteComplementos.vistaprinci(); 
   });
   $("#academicoscom").on('click',function(){
      AcademicosComp.vistaopciones();
   });
});



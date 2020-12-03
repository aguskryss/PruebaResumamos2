<?php
include ('layout.php');
include ('BD.php');
Encabezado();
?>
<div class="container">
    <br/>
                <h2 class="text-center">Insertar noticia</h2>
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6 col-12">    
                <form METHOD="POST" ACTION="insert.php" >
                    <div class="row">
                        <div class="col-12">
                            <input type="text" class="form-control" id="Titulo" name="Titulo" placeholder="Titulo">
                        </div>
                    </div>
                    <br/>
                    <div class="row">
                        <div class="col-12">
                            <input type="text" class="form-control" name="Copete" id="Copete" placeholder="Copete">
                        </div>
                    </div>
                    <br/>
                    <div class="row">
                        <div class="col-12">
                            <input type="text" class="form-control" name="URL" id="URL" placeholder="URL imagen">
                        </div>
                    </div>
                    <br/>
                    <div class="row">
                        <h5>Descripcion</h5>
                        <div class="col-12">
                            <textarea class="form-control" rows="6" name="Descripcion" id="Descripcion"> </textarea>
                        </div>
                    </div>
                    <br/>
                    <center>
                        <input type="submit" class="btn btn-primary" value="Insertar">
                    </center>
                </form>
            </div>
            <div class="col-md-3"></div>
        </div>
</div>


<?php
Footer();
?>
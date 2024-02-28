ALTER PROCEDURE UsuarioGetAll
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@IdRol INT
AS
IF ((@Nombre = '') AND (@ApellidoPaterno = '') AND (@ApellidoMaterno = '')AND (@IdRol=0))
BEGIN
	SELECT 
		IdUsuario,
		Username,
		Nombre, 
		ApellidoPaterno, 
		ApellidoMaterno,
		Email,
		Password,
		Sexo,
		Telefono,
		Celular,
		FechaNacimiento,
		CURP,
		IdRol,
		RolNombre,
		Imagen,
		IdDireccion,
		Calle,
		NumeroExterno,
		NumeroInterno,
		IdColonia,
		NombreColonia,
		CodigoPostal,
		IdMunicipio,
		NombreMunicipio,
		IdEstado,
		NombreEstado,
		IdPais,
		NombrePais
	FROM vwUsuario
	
END
ELSE 
	IF (((@Nombre <> '') OR (@ApellidoPaterno <> '') OR (@ApellidoMaterno <> '')) AND (@IdRol=0))
	BEGIN
		SELECT 
		IdUsuario,
		Username,
		Nombre, 
		ApellidoPaterno, 
		ApellidoMaterno,
		Email,
		Password,
		Sexo,
		Telefono,
		Celular,
		FechaNacimiento,
		CURP,
		IdRol,
		RolNombre,
		Imagen,
		IdDireccion,
		Calle,
		NumeroExterno,
		NumeroInterno,
		IdColonia,
		NombreColonia,
		CodigoPostal,
		IdMunicipio,
		NombreMunicipio,
		IdEstado,
		NombreEstado,
		IdPais,
		NombrePais

		FROM vwUsuario
		WHERE 
		Nombre LIKE '%'+@Nombre+'%'
		AND
		ApellidoPaterno LIKE '%'+@ApellidoPaterno+'%'
		AND
		ApellidoMaterno LIKE '%'+@ApellidoMaterno+'%'
	END
	ELSE 
		IF ((@Nombre = '') AND (@ApellidoPaterno = '') AND (@ApellidoMaterno = '') AND (@IdRol>0))
		BEGIN
			SELECT 
				IdUsuario,
				Username,
				Nombre, 
				ApellidoPaterno, 
				ApellidoMaterno,
				Email,
				Password,
				Sexo,
				Telefono,
				Celular,
				FechaNacimiento,
				CURP,
				IdRol,
				RolNombre,
				Imagen,
				IdDireccion,
				Calle,
				NumeroExterno,
				NumeroInterno,
				IdColonia,
				NombreColonia,
				CodigoPostal,
				IdMunicipio,
				NombreMunicipio,
				IdEstado,
				NombreEstado,
				IdPais,
				NombrePais

				FROM vwUsuario
				WHERE 
					IdRol = @IdRol
		END
		ELSE
			IF (((@Nombre <> '') OR (@ApellidoPaterno <> '') OR (@ApellidoMaterno <> ''))AND (@IdRol>0))
			BEGIN
				SELECT
					IdUsuario,
					Username,
					Nombre, 
					ApellidoPaterno, 
					ApellidoMaterno,
					Email,
					Password,
					Sexo,
					Telefono,
					Celular,
					FechaNacimiento,
					CURP,
					IdRol,
					RolNombre,
					Imagen,
					IdDireccion,
					Calle,
					NumeroExterno,
					NumeroInterno,
					IdColonia,
					NombreColonia,
					CodigoPostal,
					IdMunicipio,
					NombreMunicipio,
					IdEstado,
					NombreEstado,
					IdPais,
					NombrePais

					FROM vwUsuario
						WHERE 
							Nombre LIKE '%'+@Nombre+'%'
							AND
							ApellidoPaterno LIKE '%'+@ApellidoPaterno+'%'
							AND
							ApellidoMaterno LIKE '%'+@ApellidoMaterno+'%'
							AND
							IdRol = @IdRol
			END
--------------------------------------------------------------

	UsuarioGetAll
	
	UsuarioGetAll '','',''
	-----------------------
	N
		SELECT 
		Usuario.IdUsuario, 
		Usuario.UserName, 
		Usuario.Nombre, 
		Usuario.ApellidoPaterno, 
		Usuario.ApellidoMaterno, 
		Usuario.Email, 
		Usuario.Password, 
		Usuario.Sexo, 
		Usuario.Telefono, 
		Usuario.Celular, 
		Usuario.FechaNacimiento, 
		Usuario.CURP, 
		Rol.IdRol,
		Rol.Nombre AS RolNombre,
		Usuario.Imagen,
		Direccion.IdDireccion,
		Direccion.Calle,
		Direccion.NumeroExterno,
		Direccion.NumeroInterno,
		Colonia.IdColonia,
		Colonia.NombreColonia,
		Colonia.CodigoPostal,
		Municipio.IdMunicipio,
		Municipio.NombreMunicipio,
		Estado.IdEstado,
		Estado.NombreEstado,
		Pais.IdPais,
		Pais.NombrePais	


		FROM Usuario
		INNER JOIN 
		Rol ON Usuario.IdRol = Rol.IdRol
		LEFT JOIN Direccion
			ON Usuario.IdUsuario = Direccion.IdUsuario
		LEFT JOIN Colonia
			ON Direccion.IdColonia = Colonia.IdColonia
		LEFT JOIN Municipio
			ON Colonia.IdMunicipio = Municipio.IdMunicipio
		LEFT JOIN Estado
			ON Municipio.IdEstado = Estado.IdEstado
		LEFT JOIN Pais
			ON Estado.IdPais = Pais.IdPais
		WHERE 
		Usuario.Nombre LIKE '%'+ ''+'%'
		AND
		Usuario.ApellidoPaterno LIKE '%'+ 'Espinoza' +'%'
		AND
		Usuario.ApellidoMaterno LIKE '%'+ '' +'%'
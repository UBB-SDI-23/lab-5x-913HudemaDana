import {
	TableContainer,
	Paper,
	Table,
	TableHead,
	TableRow,
	TableCell,
	TableBody,
	CircularProgress,
	Container,
	IconButton,
	Tooltip,
} from "@mui/material";
import React from "react";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { BACKEND_API_URL } from "../../constants";
import { Vinyl } from "../../models/Vinyl";
import ReadMoreIcon from "@mui/icons-material/ReadMore";
import EditIcon from "@mui/icons-material/Edit";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import AddIcon from "@mui/icons-material/Add";

export const AllVinyls = () => {
	const [loading, setLoading] = useState(false);
	const [vinyls, setVinyls] = useState<Vinyl[]>([]);

	useEffect(() => {
		setLoading(true);
		fetch(`${BACKEND_API_URL}/vinyls`)
			.then((response) => response.json())
			.then((data) => {
				setVinyls(data);
				setLoading(false);
			});
	}, []);

	return (
		<Container>
			<h1>All vinyls</h1>

			{loading && <CircularProgress />}
			{!loading && vinyls.length === 0 && <p>No vinyls found</p>}
			{!loading && (
				<IconButton component={Link} sx={{ mr: 3 }} to={`/vinyls/add`}>
					<Tooltip title="Add a new vinyls" arrow>
						<AddIcon color="primary" />
					</Tooltip>
				</IconButton>
			)}
			{!loading && vinyls.length > 0 && (
				<TableContainer component={Paper}>
					<Table sx={{ minWidth: 650 }} aria-label="simple table">
						<TableHead>
							<TableRow>
								<TableCell>#</TableCell>
                                <TableCell align="center">Album Title</TableCell>
								<TableCell align="right">Edition</TableCell>
								<TableCell align="right">Durability</TableCell>
								<TableCell align="right">Size</TableCell>
								<TableCell align="center">Material</TableCell>
                                <TableCell align="center">Groove</TableCell>
                                <TableCell align="center">Speed</TableCell>
                                <TableCell align="center">Condition</TableCell>   
							</TableRow>
						</TableHead>
						<TableBody>
							{vinyls.map((vinyl, index) => (
								<TableRow key={vinyl.id}>
									<TableCell component="th" scope="row">
										{index + 1}
									</TableCell>
									<TableCell component="th" scope="row">
										<Link to={`/vinyls/${vinyl.id}/details`} title="View vinyl details">
											{vinyl.album?.name}
										</Link>
									</TableCell>
									<TableCell align="right">{vinyl.edition}</TableCell>
									<TableCell align="right">{vinyl.durablility}</TableCell>
                                    <TableCell align="right">{vinyl.size}</TableCell>
                                    <TableCell align="right">{vinyl.material}</TableCell>
                                    <TableCell align="right">{vinyl.groove}</TableCell>
                                    <TableCell align="right">{vinyl.speed}</TableCell>
                                    <TableCell align="right">{vinyl.condition}</TableCell>
									<TableCell align="right">
										<IconButton
											component={Link}
											sx={{ mr: 3 }}
											to={`/vinyls/${vinyl.id}/details`}>
											<Tooltip title="View vinyl details" arrow>
												<ReadMoreIcon color="primary" />
											</Tooltip>
										</IconButton>

										<IconButton component={Link} sx={{ mr: 3 }} to={`/vinyls/${vinyl.id}/edit`}>
											<EditIcon />
										</IconButton>

										<IconButton component={Link} sx={{ mr: 3 }} to={`/vinyls/${vinyl.id}/delete`}>
											<DeleteForeverIcon sx={{ color: "red" }} />
										</IconButton>
									</TableCell>
								</TableRow>
							))}
						</TableBody>
					</Table>
				</TableContainer>
			)}
		</Container>
	);
};
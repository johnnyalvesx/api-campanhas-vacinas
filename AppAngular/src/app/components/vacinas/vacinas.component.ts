import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Vacina } from 'src/app/Vacina';
import { VacinasService } from 'src/app/vacinas.service';

@Component({
  selector: 'app-vacinas',
  templateUrl: './vacinas.component.html',
  styleUrls: ['./vacinas.component.scss']
})
export class VacinasComponent implements OnInit {

  formulario: any;
  tituloFormulario!: string;
  vacinas!: Vacina[];
  nomeDaVacina!: string;
  vacinaId!: number;

  visibilidadeTabela: boolean = true;
  visibilidadeFormulario: boolean = false;

  modalRef!: BsModalRef;

  constructor(private vacinasService: VacinasService, private modalService: BsModalService) { }

  ngOnInit(): void {

    this.vacinasService.PegarTodasAsVacinas().subscribe(resultado => {
      this.vacinas = resultado;
    });
  }

  ExibirFormularioCadastro(): void {
    this.visibilidadeTabela = false;
    this.visibilidadeFormulario = true;
    this.tituloFormulario = 'Nova vacina';
    this.formulario = new FormGroup({
      nomeDaVacina: new FormControl(null),
      dica: new FormControl(null),
    });
  }

  ExibirFormularioAtualizacao(vacinaId: number): void {
    this.visibilidadeTabela = false;
    this.visibilidadeFormulario = true;

    this.vacinasService.PegarVacinaPeloId(vacinaId).subscribe(resultado => {
      this.tituloFormulario = `Atualizar ${resultado.nomeDaVacina} ${resultado.dica}`;

      this.formulario = new FormGroup({
        vacinaId: new FormControl(resultado.vacinaId),
        nomeDaVacina: new FormControl(resultado.nomeDaVacina),
        dica: new FormControl(resultado.dica),
      });
    });
  }

  EnviarFormulario(): void {
    const vacina: Vacina = this.formulario.value;

    if (vacina.vacinaId > 0) {
      this.vacinasService.AtualizarVacina(vacina).subscribe(resultado => {
        this.visibilidadeFormulario = false;
        this.visibilidadeTabela = true;
        alert('Vacina atualizada com sucesso.');
        this.vacinasService.PegarTodasAsVacinas().subscribe((registros) => {
          this.vacinas = registros;
        });
      })
    } else {
      this.vacinasService.SalvarVacina(vacina).subscribe((resultado) => {
        this.visibilidadeFormulario = false;
        this.visibilidadeTabela = true;
        alert('Vacina cadastrada com sucesso.');
        this.vacinasService.PegarTodasAsVacinas().subscribe((registros) => {
          this.vacinas = registros;
        });
      });
    }
  }

  Voltar(): void {
    this.visibilidadeTabela = true;
    this.visibilidadeFormulario = false;
  }

  ExibirConfirmacaoExclusao(vacinaId: number, nomeDaVacina: string, conteudoModal: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(conteudoModal);
    this.vacinaId = vacinaId;
    this.nomeDaVacina = nomeDaVacina;
  }

  ExcluirVacina(vacinaId: number) {
    this.vacinasService.ExcluirVacina(vacinaId).subscribe(resultado => {
      this.modalRef.hide();
      alert('Vacina excluída com sucesso.');
      this.vacinasService.PegarTodasAsVacinas().subscribe(registros => {
        this.vacinas = registros;
      })
    })
  }

}
